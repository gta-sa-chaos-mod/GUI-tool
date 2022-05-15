// Copyright (c) 2019 Lordmau5
using GTAChaos.Effects;
using GTAChaos.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GTAChaos.Forms
{
    public partial class Form1 : Form
    {
        private readonly string configPath = Path.Combine(Directory.GetCurrentDirectory(), "config.cfg");

        private readonly Stopwatch stopwatch;
        private readonly Dictionary<string, EffectTreeNode> idToEffectNodeMap = new();
        private IStreamConnection stream;

        private readonly System.Timers.Timer websocketReconnectionTimer;
        private int elapsedCount;
        private int timesUntilRapidFire;

#if DEBUG
        private readonly bool debug = true;
#else

        private readonly bool debug = false;
#endif

        public Form1()
        {
            InitializeComponent();

            Text = $"GTA Trilogy Chaos Mod v{Shared.Version}";
            if (!debug)
            {
                gameToolStripMenuItem.Visible = false;
                tabs.TabPages.Remove(tabExperimental);
                textBoxExperimentalEffectName.Visible = false;
                buttonExperimentalRunEffect.Visible = false;
            }
            else
            {
                Text += " (DEBUG)";
                textBoxMultiplayerServer.Text = "ws://localhost:12312";
            }

            tabs.TabPages.Remove(tabPolls);

            stopwatch = new Stopwatch();

            EffectDatabase.PopulateEffects("san_andreas");
            PopulateEffectTreeList();

            PopulateMainCooldowns();
            PopulatePresets();

            tabs.TabPages.Remove(tabStream);

            PopulateVotingTimes();
            PopulateVotingCooldowns();

            TryLoadConfig();

            timesUntilRapidFire = new Random().Next(10, 15);

            WebsocketHandler.INSTANCE.ConnectWebsocket();
            WebsocketHandler.INSTANCE.OnSocketMessage += OnSocketMessage;

            websocketReconnectionTimer = new System.Timers.Timer()
            {
                Interval = 1000,
                AutoReset = true
            };
            websocketReconnectionTimer.Elapsed += WebsocketReconnectionTimer_Elapsed;
            websocketReconnectionTimer.Start();
        }

        private void WebsocketReconnectionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // This is hacky but it works
            WebsocketHandler.INSTANCE.ConnectWebsocket();
        }

        private void OnSocketMessage(object sender, SocketMessageEventArgs e)
        {
            try
            {
                var json = JObject.Parse(e.Data);

                var type = Convert.ToString(json["type"]);
                var state = Convert.ToString(json["state"]);

                if (type == "ChaosMod" && state == "auto_start")
                {
                    Invoke(new Action(() =>
                    {
                        DoAutostart();
                    }));
                }
            }
            catch (Exception) { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void TryLoadConfig()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader streamReader = new StreamReader(configPath))
                using (JsonReader reader = new JsonTextReader(streamReader))
                {
                    Config.SetInstance(serializer.Deserialize<Config>(reader));
                    RandomHandler.SetSeed(Config.Instance().Seed);
                }
            }
            catch (Exception) { }

            LoadPreset(Config.Instance().EnabledEffects);
            UpdateInterface();
        }

        private void SaveConfig()
        {
            try
            {
                Config.Instance().EnabledEffects.Clear();
                foreach (var effect in EffectDatabase.EnabledEffects)
                {
                    Config.Instance().EnabledEffects.Add(effect.GetId());
                }

                JsonSerializer serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(configPath))
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, Config.Instance());
                }
            }
            catch (Exception) { }
        }

        private void UpdateInterface()
        {
            bool found = false;
            foreach (MainCooldownComboBoxItem item in comboBoxMainCooldown.Items)
            {
                if (item.Time == Config.Instance().MainCooldown)
                {
                    comboBoxMainCooldown.SelectedItem = item;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                comboBoxMainCooldown.SelectedIndex = 3;
                Config.Instance().MainCooldown = 1000 * 60;
            }

            checkBoxAutoStart.Checked = Config.Instance().AutoStart;

            checkBoxStreamAllowOnlyEnabledEffects.Checked = Config.Instance().StreamAllowOnlyEnabledEffectsRapidFire;

            found = false;
            foreach (VotingTimeComboBoxItem item in comboBoxVotingTime.Items)
            {
                if (item.VotingTime == Config.Instance().StreamVotingTime)
                {
                    comboBoxVotingTime.SelectedItem = item;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                comboBoxVotingTime.SelectedIndex = 0;
                Config.Instance().StreamVotingTime = 1000 * 30;
            }

            found = false;
            foreach (VotingCooldownComboBoxItem item in comboBoxVotingCooldown.Items)
            {
                if (item.VotingCooldown == Config.Instance().StreamVotingCooldown)
                {
                    comboBoxVotingCooldown.SelectedItem = item;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                comboBoxVotingCooldown.SelectedIndex = 1;
                Config.Instance().StreamVotingCooldown = 1000 * 60;
            }

            textBoxStreamAccessToken.Text = Config.Instance().StreamAccessToken;
            textBoxStreamClientID.Text = Config.Instance().StreamClientID;

            checkBoxPlayAudioForEffects.Checked = Config.Instance().PlayAudioForEffects;

            checkBoxShowLastEffectsMain.Checked = Config.Instance().MainShowLastEffects;
            checkBoxShowLastEffectsStream.Checked = Config.Instance().StreamShowLastEffects;
            checkBoxStream3TimesCooldown.Checked = Config.Instance().Stream3TimesCooldown;
            checkBoxStreamCombineVotingMessages.Checked = Config.Instance().StreamCombineChatMessages;
            checkBoxStreamEnableMultipleEffects.Checked = Config.Instance().StreamEnableMultipleEffects;
            checkBoxStreamEnableRapidFire.Checked = Config.Instance().StreamEnableRapidFire;

            checkBoxStreamMajorityVotes.Checked = Config.Instance().StreamMajorityVotes;
            checkBoxStreamEnableMultipleEffects.Enabled = Config.Instance().StreamMajorityVotes;

            checkBoxTwitchUsePolls.Checked = Config.Instance().TwitchUsePolls;
            checkBoxTwitchPollsPostMessages.Checked = Config.Instance().TwitchPollsPostMessages;
            numericUpDownTwitchPollsBitsCost.Value = Config.Instance().TwitchPollsBitsCost;
            numericUpDownTwitchPollsChannelPointsCost.Value = Config.Instance().TwitchPollsChannelPointsCost;

            checkBoxExperimental_EnableAllEffects.Checked = Config.Instance().Experimental_EnableAllEffects;
            checkBoxExperimental_RunEffectOnAutoStart.Checked = Config.Instance().Experimental_RunEffectOnAutoStart;
            textBoxExperimentalEffectName.Text = Config.Instance().Experimental_EffectName;
            checkBoxExperimentalYouTubeConnection.Checked = Config.Instance().Experimental_YouTubeConnection;

            textBoxSeed.Text = Config.Instance().Seed;

            /*
             * Update selections
             */
        }

        public void AddEffectToListBox(AbstractEffect effect)
        {
            string description = "Invalid";
            if (effect != null)
            {
                description = effect.GetDisplayName();
                if (!string.IsNullOrEmpty(effect.Word))
                {
                    description += $" ({effect.Word})";
                }
            }

            ListBox listBox = Shared.IsStreamMode ? listLastEffectsStream : listLastEffectsMain;
            listBox.Items.Insert(0, description);
            if (listBox.Items.Count > 7)
            {
                listBox.Items.RemoveAt(7);
            }
        }

        private void CallEffect(AbstractEffect effect = null)
        {
            if (effect == null)
            {
                if (Config.Instance().Experimental_EnableAllEffects)
                {
                    foreach (AbstractEffect e in EffectDatabase.EnabledEffects)
                    {
                        EffectDatabase.RunEffect(e);
                        e?.ResetStreamVoter();
                    }
                }
                else
                {
                    effect = EffectDatabase.GetRandomEffect(true);
                    if (Shared.Multiplayer != null)
                    {
                        Shared.Multiplayer.SendEffect(effect);
                    }
                    else
                    {
                        effect = EffectDatabase.RunEffect(effect);
                        effect?.ResetStreamVoter();

                        if (effect != null)
                        {
                            AddEffectToListBox(effect);
                        }
                    }
                }
            }
            else
            {
                if (Shared.Multiplayer != null)
                {
                    Shared.Multiplayer.SendEffect(effect);
                }
                else
                {
                    EffectDatabase.RunEffect(effect);
                    AddEffectToListBox(effect);
                }
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (Shared.IsStreamMode)
            {
                TickStream();
            }
            else
            {
                TickMain();
            }
        }

        private void TickMain()
        {
            if (!Shared.TimerEnabled) return;

            int value = Math.Max(1, (int)stopwatch.ElapsedMilliseconds);

            // Hack to fix Windows' broken-ass progress bar handling
            progressBarMain.Value = Math.Min(value, progressBarMain.Maximum);
            progressBarMain.Value = Math.Min(value - 1, progressBarMain.Maximum);

            int remaining = (int)Math.Max(0, Config.Instance().MainCooldown - stopwatch.ElapsedMilliseconds);

            WebsocketHandler.INSTANCE.SendTimeToGame(remaining, Config.Instance().MainCooldown);

            if (stopwatch.ElapsedMilliseconds - elapsedCount > 100)
            {
                Shared.Multiplayer?.SendTimeUpdate(remaining, Config.Instance().MainCooldown);

                elapsedCount = (int)stopwatch.ElapsedMilliseconds;
            }

            if (stopwatch.ElapsedMilliseconds >= Config.Instance().MainCooldown)
            {
                progressBarMain.Value = 0;
                CallEffect();
                elapsedCount = 0;
                stopwatch.Restart();
            }
        }

        private void TickStream()
        {
            if (!Shared.TimerEnabled) return;

            if (Shared.StreamVotingMode == 1)
            {
                if (progressBarStream.Maximum != Config.Instance().StreamVotingTime)
                {
                    progressBarStream.Maximum = Config.Instance().StreamVotingTime;
                }

                // Hack to fix Windows' broken-ass progress bar handling
                int value = Math.Max(1, (int)stopwatch.ElapsedMilliseconds);
                progressBarStream.Value = Math.Max(progressBarStream.Maximum - value, 0);
                progressBarStream.Value = Math.Max(progressBarStream.Maximum - value - 1, 0);

                int remaining = (int)Math.Max(0, Config.Instance().StreamVotingTime - stopwatch.ElapsedMilliseconds);

                WebsocketHandler.INSTANCE.SendTimeToGame(remaining, Config.Instance().StreamVotingTime, "Voting");

                if (stopwatch.ElapsedMilliseconds - elapsedCount > 100)
                {
                    Shared.Multiplayer?.SendTimeUpdate(remaining, Config.Instance().StreamVotingTime);

                    stream?.SendEffectVotingToGame();

                    elapsedCount = (int)stopwatch.ElapsedMilliseconds;
                }

                bool didFinish;

                if (Config.Instance().TwitchUsePolls && stream != null && !Config.Instance().Experimental_YouTubeConnection)
                {
                    didFinish = stream.GetRemaining() == 0;

                    if (stopwatch.ElapsedMilliseconds >= Config.Instance().StreamVotingTime)
                    {
                        long millisecondsOver = stopwatch.ElapsedMilliseconds - Config.Instance().StreamVotingTime;
                        int waitLeft = Math.Max(0, 15000 - decimal.ToInt32(millisecondsOver));
                        labelStreamCurrentMode.Text = $"Current Mode: Waiting For Poll... ({Math.Ceiling((float)waitLeft / 1000)}s left)";

                        if (waitLeft == 0)
                        {
                            labelStreamCurrentMode.Text = "Current Mode: Cooldown (Poll Failed)";

                            WebsocketHandler.INSTANCE.SendTimeToGame(0);
                            Shared.Multiplayer?.SendTimeUpdate(0, Config.Instance().StreamVotingCooldown);
                            elapsedCount = 0;

                            progressBarStream.Value = 0;
                            progressBarStream.Maximum = Config.Instance().StreamVotingCooldown;

                            stopwatch.Restart();
                            Shared.StreamVotingMode = 0;

                            stream?.SetVoting(3, timesUntilRapidFire, null);

                            return;
                        }
                    }
                }
                else
                {
                    didFinish = stopwatch.ElapsedMilliseconds >= Config.Instance().StreamVotingTime;
                }

                if (didFinish)
                {
                    WebsocketHandler.INSTANCE.SendTimeToGame(0);
                    Shared.Multiplayer?.SendTimeUpdate(0, Config.Instance().StreamVotingCooldown);
                    elapsedCount = 0;

                    progressBarStream.Value = 0;
                    progressBarStream.Maximum = Config.Instance().StreamVotingCooldown;

                    stopwatch.Restart();
                    Shared.StreamVotingMode = 0;

                    labelStreamCurrentMode.Text = "Current Mode: Cooldown";

                    if (stream != null)
                    {
                        List<IVotingElement> elements = stream.GetVotedEffects();

                        bool zeroVotes = true;
                        foreach(var e in elements)
                        {
                            if (e.GetVotes() > 0)
                            {
                                zeroVotes = false;
                            }
                        }

                        stream.SetVoting(0, timesUntilRapidFire, zeroVotes ? null : elements);
                        if (!zeroVotes)
                        {
                            foreach(var e in elements)
                            {
                                float multiplier = e.GetEffect().GetMultiplier();
                                e.GetEffect().SetMultiplier(multiplier / elements.Count);
                                CallEffect(e.GetEffect());
                                e.GetEffect().SetMultiplier(multiplier);
                            }
                        }
                    }
                }
            }
            else if (Shared.StreamVotingMode == 2)
            {
                if (progressBarStream.Maximum != 1000 * 10)
                {
                    progressBarStream.Maximum = 1000 * 10;
                }

                // Hack to fix Windows' broken-ass progress bar handling
                int value = Math.Max(1, (int)stopwatch.ElapsedMilliseconds);
                progressBarStream.Value = Math.Max(progressBarStream.Maximum - value, 0);
                progressBarStream.Value = Math.Max(progressBarStream.Maximum - value - 1, 0);

                int remaining = (int)Math.Max(0, (1000 * 10) - stopwatch.ElapsedMilliseconds);

                WebsocketHandler.INSTANCE.SendTimeToGame(remaining, 10000, "Rapid-Fire");

                if (stopwatch.ElapsedMilliseconds - elapsedCount > 100)
                {
                    Shared.Multiplayer?.SendTimeUpdate(remaining, 10000);

                    elapsedCount = (int)stopwatch.ElapsedMilliseconds;
                }

                if (stopwatch.ElapsedMilliseconds >= 1000 * 10) // Set 10 seconds
                {
                    WebsocketHandler.INSTANCE.SendTimeToGame(0);
                    Shared.Multiplayer?.SendTimeUpdate(0, Config.Instance().StreamVotingCooldown);
                    elapsedCount = 0;

                    progressBarStream.Value = 0;
                    progressBarStream.Maximum = Config.Instance().StreamVotingCooldown;

                    stopwatch.Restart();
                    Shared.StreamVotingMode = 0;

                    labelStreamCurrentMode.Text = "Current Mode: Cooldown";

                    stream?.SetVoting(0, timesUntilRapidFire);
                }
            }
            else if (Shared.StreamVotingMode == 0)
            {
                if (progressBarStream.Maximum != Config.Instance().StreamVotingCooldown)
                {
                    progressBarStream.Maximum = Config.Instance().StreamVotingCooldown;
                }

                // Hack to fix Windows' broken-ass progress bar handling
                int value = Math.Max(1, (int)stopwatch.ElapsedMilliseconds);
                progressBarStream.Value = Math.Min(value + 1, progressBarStream.Maximum);
                progressBarStream.Value = Math.Min(value, progressBarStream.Maximum);

                int remaining = (int)Math.Max(0, Config.Instance().StreamVotingCooldown - stopwatch.ElapsedMilliseconds);

                WebsocketHandler.INSTANCE.SendTimeToGame(remaining, Config.Instance().StreamVotingCooldown, "Cooldown");

                if (stopwatch.ElapsedMilliseconds - elapsedCount > 100)
                {
                    Shared.Multiplayer?.SendTimeUpdate(remaining, Config.Instance().StreamVotingCooldown);

                    elapsedCount = (int)stopwatch.ElapsedMilliseconds;
                }

                if (stopwatch.ElapsedMilliseconds >= Config.Instance().StreamVotingCooldown)
                {
                    elapsedCount = 0;

                    if (Config.Instance().StreamEnableRapidFire)
                    {
                        timesUntilRapidFire--;
                    }

                    if (timesUntilRapidFire == 0 && Config.Instance().StreamEnableRapidFire)
                    {
                        progressBarStream.Value = progressBarStream.Maximum = 1000 * 10;

                        timesUntilRapidFire = new Random().Next(10, 15);

                        Shared.StreamVotingMode = 2;
                        labelStreamCurrentMode.Text = "Current Mode: Rapid-Fire";

                        stream?.SetVoting(2, timesUntilRapidFire);
                    }
                    else
                    {
                        progressBarStream.Value = progressBarStream.Maximum = Config.Instance().StreamVotingTime;

                        Shared.StreamVotingMode = 1;
                        labelStreamCurrentMode.Text = "Current Mode: Voting";

                        stream?.SetVoting(1, timesUntilRapidFire);
                    }
                    stopwatch.Restart();
                }
            }
        }

        private void PopulateEffectTreeList()
        {
            enabledEffectsView.Nodes.Clear();
            idToEffectNodeMap.Clear();

            // Add Categories
            foreach (Category cat in Category.Categories)
            {
                if (cat.GetEffectCount() > 0)
                {
                    enabledEffectsView.Nodes.Add(new CategoryTreeNode(cat));
                }
            }

            // Add Effects
            foreach (AbstractEffect effect in EffectDatabase.Effects)
            {
                if (idToEffectNodeMap.ContainsKey(effect.GetId()))
                {
                    MessageBox.Show($"Tried adding effect with ID that was already present: '{effect.GetId()}'");
                }

                TreeNode node = enabledEffectsView.Nodes.Find(effect.Category.Name, false).FirstOrDefault();

                string Description = effect.GetDisplayName();

                if (effect.Word.Equals("IWontTakeAFreePass"))
                {
                    Description += " (Fake)";
                }

                EffectTreeNode addedNode = new EffectTreeNode(effect, Description)
                {
                    Checked = true,
                };
                node.Nodes.Add(addedNode);
                idToEffectNodeMap[effect.GetId()] = addedNode;
            }
        }

        private void PopulatePresets()
        {
            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.Checked = false;
                CheckAllChildNodes(node, false);
                node.UpdateCategory();
            }
        }

        private void PopulateMainCooldowns()
        {
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("10 seconds", 1000 * 10));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("20 seconds", 1000 * 20));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("30 seconds", 1000 * 30));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("1 minute", 1000 * 60));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("2 minutes", 1000 * 60 * 2));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("3 minutes", 1000 * 60 * 3));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("5 minutes", 1000 * 60 * 5));
            comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("10 minutes", 1000 * 60 * 10));

            if (debug)
            {
                comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("DEBUG - 1 second", 1000));
                comboBoxMainCooldown.Items.Add(new MainCooldownComboBoxItem("DEBUG - 10ms", 10));
            }

            comboBoxMainCooldown.SelectedIndex = 3;

            Config.Instance().MainCooldown = 1000 * 60;
        }

        private class MainCooldownComboBoxItem
        {
            public readonly string Text;
            public readonly int Time;

            public MainCooldownComboBoxItem(string text, int time)
            {
                Text = text;
                Time = time;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void MainCooldownComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainCooldownComboBoxItem item = (MainCooldownComboBoxItem)comboBoxMainCooldown.SelectedItem;
            Config.Instance().MainCooldown = item.Time;

            if (!Shared.TimerEnabled)
            {
                progressBarMain.Value = 0;
                progressBarMain.Maximum = Config.Instance().MainCooldown;
                elapsedCount = 0;
                stopwatch.Reset();
            }
        }

        private void PopulateVotingTimes()
        {
            comboBoxVotingTime.Items.Add(new VotingTimeComboBoxItem("30 seconds", 1000 * 30));
            comboBoxVotingTime.Items.Add(new VotingTimeComboBoxItem("1 minute", 1000 * 60));

            comboBoxVotingTime.SelectedIndex = 0;

            Config.Instance().StreamVotingTime = 1000 * 30;
        }

        private class VotingTimeComboBoxItem
        {
            public readonly int VotingTime;
            public readonly string Text;

            public VotingTimeComboBoxItem(string text, int votingTime)
            {
                Text = text;
                VotingTime = votingTime;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void ComboBoxVotingTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            VotingTimeComboBoxItem item = (VotingTimeComboBoxItem)comboBoxVotingTime.SelectedItem;
            Config.Instance().StreamVotingTime = item.VotingTime;
        }

        private void PopulateVotingCooldowns()
        {
            comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("30 seconds", 1000 * 30));
            comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("1 minute", 1000 * 60));
            comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("2 minutes", 1000 * 60 * 2));
            comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("3 minutes", 1000 * 60 * 3));
            comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("5 minutes", 1000 * 60 * 5));
            comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("10 minutes", 1000 * 60 * 10));

            if (debug)
            {
                comboBoxVotingCooldown.Items.Add(new VotingCooldownComboBoxItem("5 seconds", 1000 * 5));
            }

            comboBoxVotingCooldown.SelectedIndex = 1;

            Config.Instance().StreamVotingCooldown = 1000 * 60;
        }

        private class VotingCooldownComboBoxItem
        {
            public readonly int VotingCooldown;
            public readonly string Text;

            public VotingCooldownComboBoxItem(string text, int votingCooldown)
            {
                Text = text;
                VotingCooldown = votingCooldown;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void ComboBoxVotingCooldown_SelectedIndexChanged(object sender, EventArgs e)
        {
            VotingCooldownComboBoxItem item = (VotingCooldownComboBoxItem)comboBoxVotingCooldown.SelectedItem;
            Config.Instance().StreamVotingCooldown = item.VotingCooldown;
        }

        private void DoAutostart()
        {
            if (!checkBoxAutoStart.Checked) return;

            elapsedCount = 0;
            stopwatch.Reset();
            SetEnabled(true);

            if (Config.Instance().Experimental_RunEffectOnAutoStart && !Shared.IsStreamMode)
            {
                CallEffect();
            }
        }

        private void SetEnabled(bool enabled)
        {
            Shared.TimerEnabled = enabled;
            if (Shared.TimerEnabled)
            {
                stopwatch.Start();
            }
            else
            {
                stopwatch.Stop();
            }

            buttonMainToggle.Enabled = true;
            (Shared.IsStreamMode ? buttonStreamToggle : buttonMainToggle).Text = Shared.TimerEnabled ? "Stop / Pause" : "Start / Resume";
            comboBoxMainCooldown.Enabled =
                buttonSwitchMode.Enabled =
                buttonResetMain.Enabled =
                buttonResetStream.Enabled = !Shared.TimerEnabled;

            comboBoxVotingTime.Enabled =
                comboBoxVotingCooldown.Enabled =
                textBoxSeed.Enabled = !Shared.TimerEnabled;
        }

        private void ButtonMainToggle_Click(object sender, EventArgs e)
        {
            SetEnabled(!Shared.TimerEnabled);
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node is EffectTreeNode etn)
                {
                    EffectDatabase.SetEffectEnabled(etn.Effect, etn.Checked);
                }

                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void EnabledEffectsView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node is EffectTreeNode etn)
                {
                    EffectDatabase.SetEffectEnabled(etn.Effect, etn.Checked);
                }

                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }

                foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
                {
                    node.UpdateCategory();
                }
            }
        }

        private void LoadPreset(List<string> enabledEffects)
        {
            PopulatePresets();

            foreach (string effect in enabledEffects)
            {
                if (idToEffectNodeMap.TryGetValue(effect, out EffectTreeNode node))
                {
                    node.Checked = true;
                    EffectDatabase.SetEffectEnabled(node.Effect, true);
                }
            }

            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.UpdateCategory();
            }
        }

        private class CategoryTreeNode : TreeNode
        {
            private readonly Category category;

            public CategoryTreeNode(Category _category)
            {
                category = _category;
                Name = Text = category.Name;
            }

            public void UpdateCategory()
            {
                bool newChecked = true;
                int enabled = 0;
                foreach (TreeNode node in Nodes)
                {
                    if (node.Checked)
                    {
                        enabled++;
                    }
                    else
                    {
                        newChecked = false;
                    }
                }
                Checked = newChecked;
                Text = Name + $" ({enabled}/{Nodes.Count})";
            }
        }

        private class EffectTreeNode : TreeNode
        {
            public readonly AbstractEffect Effect;

            public EffectTreeNode(AbstractEffect effect, string description)
            {
                Effect = effect;

                Name = Text = description;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Preset File|*.cfg",
                Title = "Load Preset"
            };
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                string content = System.IO.File.ReadAllText(dialog.FileName);
                string[] enabledEffects = content.Split(',');
                List<string> enabledEffectList = new List<string>();
                foreach (string effect in enabledEffects)
                {
                    enabledEffectList.Add(effect);
                }
                LoadPreset(enabledEffectList);
            }

            dialog.Dispose();
        }

        private void SavePresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> enabledEffects = new List<string>();
            foreach (EffectTreeNode node in idToEffectNodeMap.Values)
            {
                if (node.Checked)
                {
                    enabledEffects.Add(node.Effect.GetId());
                }
            }
            string joined = string.Join(",", enabledEffects);

            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Preset File|*.cfg",
                Title = "Save Preset"
            };
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                System.IO.File.WriteAllText(dialog.FileName, joined);
            }

            dialog.Dispose();
        }

        private async void ButtonConnectStream_Click(object sender, EventArgs e)
        {
            if (stream?.IsConnected() == true || buttonConnectStream.Text == "Disconnect")
            {
                stream?.Kill();
                stream = null;

                comboBoxVotingTime.Enabled = true;
                comboBoxVotingCooldown.Enabled = true;

                textBoxStreamAccessToken.Enabled = true;
                textBoxStreamClientID.Enabled = true;

                buttonStreamToggle.Enabled = false;

                checkBoxTwitchUsePolls.Enabled = true;

                buttonConnectStream.Text = "Connect to Stream";

                if (!tabs.TabPages.Contains(tabEffects))
                {
                    tabs.TabPages.Insert(tabs.TabPages.IndexOf(tabStream), tabEffects);
                }

                SetEnabled(false);

                return;
            }

            if (!string.IsNullOrEmpty(Config.Instance().StreamAccessToken) && !string.IsNullOrEmpty(Config.Instance().StreamClientID))
            {
                buttonConnectStream.Enabled = false;
                textBoxStreamAccessToken.Enabled = false;
                textBoxStreamClientID.Enabled = false;

                if (Config.Instance().Experimental_YouTubeConnection)
                {
                    stream = new YouTubeChatConnection();
                }
                else
                {
                    if (Config.Instance().TwitchUsePolls)
                    {
                        stream = new TwitchPollConnection();
                    }
                    else
                    {
                        stream = new TwitchChatConnection();
                    }
                }

                stream.OnRapidFireEffect += (_sender, rapidFireArgs) =>
                {
                    Invoke(new Action(() =>
                    {
                        if (Shared.StreamVotingMode == 2)
                        {
                            if (Shared.Multiplayer != null)
                            {
                                Shared.Multiplayer.SendEffect(rapidFireArgs.Effect, 1000 * 15);
                            }
                            else
                            {
                                rapidFireArgs.Effect.RunEffect(-1, 1000 * 15);
                                AddEffectToListBox(rapidFireArgs.Effect);
                            }
                        }
                    }));
                };

                stream.OnLoginError += (_sender, _e) =>
                {
                    MessageBox.Show("There was an error trying to log in to the account. Invalid Access Token?", "Stream Login Error");
                    Invoke(new Action(() =>
                    {
                        buttonConnectStream.Enabled = true;
                        textBoxStreamAccessToken.Enabled = true;
                        textBoxStreamClientID.Enabled = true;
                    }));
                    stream?.Kill();
                    stream = null;
                };

                stream.OnConnected += (_sender, _e) =>
                {
                    Invoke(new Action(() =>
                    {
                        buttonConnectStream.Enabled = true;
                        buttonStreamToggle.Enabled = true;

                        buttonConnectStream.Text = "Disconnect";

                        textBoxStreamAccessToken.Enabled = false;
                        textBoxStreamClientID.Enabled = false;

                        checkBoxTwitchUsePolls.Enabled = false;
                    }));
                };

                stream.OnDisconnected += (_sender, _e) =>
                {
                    Invoke(new Action(() =>
                    {
                        stream = null;

                        comboBoxVotingTime.Enabled = true;
                        comboBoxVotingCooldown.Enabled = true;

                        textBoxStreamAccessToken.Enabled = true;
                        textBoxStreamClientID.Enabled = true;

                        buttonStreamToggle.Enabled = false;

                        checkBoxTwitchUsePolls.Enabled = true;

                        buttonConnectStream.Text = "Connect to Stream";

                        if (!tabs.TabPages.Contains(tabEffects))
                        {
                            tabs.TabPages.Insert(tabs.TabPages.IndexOf(tabStream), tabEffects);
                        }

                        SetEnabled(false);
                    }));
                };

                bool connected = await stream.TryConnect();
                if (!connected)
                {
                    MessageBox.Show("There was an error trying to log in to the account. Invalid Access Token?", "Stream Login Error");

                    buttonConnectStream.Enabled = true;
                    textBoxStreamAccessToken.Enabled = true;
                    textBoxStreamClientID.Enabled = true;

                    stream?.Kill();
                    stream = null;
                    return;
                }
            }
        }

        private void UpdateStreamConnectButtonState()
        {
            buttonConnectStream.Enabled = !string.IsNullOrEmpty(Config.Instance().StreamAccessToken)
                && !string.IsNullOrEmpty(Config.Instance().StreamClientID);
        }

        private void TextBoxOAuth_TextChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamAccessToken = textBoxStreamAccessToken.Text;

            UpdateStreamConnectButtonState();
        }

        private void SwitchMode(bool isStreamMode)
        {
            if (!isStreamMode)
            {
                buttonSwitchMode.Text = "Stream";

                if (!tabs.TabPages.Contains(tabMain))
                {
                    tabs.TabPages.Insert(0, tabMain);
                }
                tabs.SelectedIndex = 0;
                tabs.TabPages.Remove(tabStream);

                tabs.TabPages.Remove(tabPolls);

                listLastEffectsMain.Items.Clear();
                progressBarMain.Value = 0;

                elapsedCount = 0;

                stopwatch.Reset();
                SetEnabled(false);
            }
            else
            {
                buttonSwitchMode.Text = "Main";

                if (!tabs.TabPages.Contains(tabStream))
                {
                    tabs.TabPages.Insert(0, tabStream);
                }
                tabs.SelectedIndex = 0;
                tabs.TabPages.Remove(tabMain);

                if (Config.Instance().TwitchUsePolls && !tabs.TabPages.Contains(tabPolls))
                {
                    tabs.TabPages.Insert(2, tabPolls);
                }

                listLastEffectsStream.Items.Clear();
                progressBarStream.Value = 0;

                elapsedCount = 0;

                stopwatch.Reset();
                SetEnabled(false);
            }
        }

        private void ButtonSwitchMode_Click(object sender, EventArgs e)
        {
            Shared.IsStreamMode = !Shared.IsStreamMode;
            SwitchMode(Shared.IsStreamMode);
        }

        private void ButtonStreamToggle_Click(object sender, EventArgs e)
        {
            SetEnabled(!Shared.TimerEnabled);
        }

        private void TextBoxSeed_TextChanged(object sender, EventArgs e)
        {
            Config.Instance().Seed = textBoxSeed.Text;
            RandomHandler.SetSeed(Config.Instance().Seed);
        }

        private void ButtonResetMain_Click(object sender, EventArgs e)
        {
            SetEnabled(false);
            RandomHandler.SetSeed(Config.Instance().Seed);
            stopwatch.Reset();
            elapsedCount = 0;
            progressBarMain.Value = 0;
            buttonMainToggle.Enabled = true;
            buttonMainToggle.Text = "Start / Resume";
        }

        private void CheckBoxShowLastEffectsMain_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().MainShowLastEffects
                = listLastEffectsMain.Visible
                = checkBoxShowLastEffectsMain.Checked;
        }

        private void CheckBoxShowLastEffectsStream_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamShowLastEffects
                = listLastEffectsStream.Visible
                = checkBoxShowLastEffectsStream.Checked;
        }

        private void CheckBoxStreamAllowOnlyEnabledEffects_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamAllowOnlyEnabledEffectsRapidFire = checkBoxStreamAllowOnlyEnabledEffects.Checked;
        }

        private void ButtonResetStream_Click(object sender, EventArgs e)
        {
            SetEnabled(false);
            RandomHandler.SetSeed(Config.Instance().Seed);
            stopwatch.Reset();
            elapsedCount = 0;
            labelStreamCurrentMode.Text = "Current Mode: Cooldown";
            Shared.StreamVotingMode = 0;
            timesUntilRapidFire = new Random().Next(10, 15);
            progressBarStream.Value = 0;
            buttonStreamToggle.Enabled = stream?.IsConnected() == true;
            buttonStreamToggle.Text = "Start / Resume";
        }

        private void CheckBoxStream3TimesCooldown_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().Stream3TimesCooldown = checkBoxStream3TimesCooldown.Checked;
        }

        private void ButtonEffectsToggleAll_Click(object sender, EventArgs e)
        {
            bool oneEnabled = false;
            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                if (node.Checked)
                {
                    oneEnabled = true;
                    break;
                }

                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Checked)
                    {
                        oneEnabled = true;
                        break;
                    }
                }
            }

            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.Checked = !oneEnabled;
                CheckAllChildNodes(node, !oneEnabled);
                node.UpdateCategory();
            }
        }

        private void ViceCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shared.SelectedGame = "vice_city";
            Config.Instance().EnabledEffects.Clear();
            EffectDatabase.PopulateEffects("vice_city");
            PopulateEffectTreeList();

            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.Checked = false;
                CheckAllChildNodes(node, false);
                node.UpdateCategory();
            }

            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.UpdateCategory();
            }
        }

        private void SanAndreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shared.SelectedGame = "san_andreas";
            Config.Instance().EnabledEffects.Clear();
            EffectDatabase.PopulateEffects("san_andreas");
            PopulateEffectTreeList();

            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.Checked = false;
                CheckAllChildNodes(node, false);
                node.UpdateCategory();
            }

            foreach (CategoryTreeNode node in enabledEffectsView.Nodes)
            {
                node.UpdateCategory();
            }
        }

        private void CheckBoxStreamCombineVotingMessages_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamCombineChatMessages = checkBoxStreamCombineVotingMessages.Checked;
        }

        private void UpdatePollTabVisibility()
        {
            if (Config.Instance().TwitchUsePolls)
            {
                if (!tabs.TabPages.Contains(tabPolls) && Shared.IsStreamMode)
                {
                    tabs.TabPages.Insert(2, tabPolls);
                }
            }
            else
            {
                tabs.TabPages.Remove(tabPolls);
            }
        }

        private void CheckBoxTwitchUsePolls_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().TwitchUsePolls = checkBoxTwitchUsePolls.Checked;
            UpdatePollTabVisibility();
        }

        private void CheckBoxStreamEnableMultipleEffects_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamEnableMultipleEffects = checkBoxStreamEnableMultipleEffects.Checked;
        }

        private void NumericUpDownTwitchPollsBitsCost_ValueChanged(object sender, EventArgs e)
        {
            Config.Instance().TwitchPollsBitsCost = decimal.ToInt32(numericUpDownTwitchPollsBitsCost.Value);
        }

        private void NumericUpDownTwitchPollsChannelPointsCost_ValueChanged(object sender, EventArgs e)
        {
            Config.Instance().TwitchPollsChannelPointsCost = decimal.ToInt32(numericUpDownTwitchPollsChannelPointsCost.Value);
        }

        private void CheckBoxTwitchPollsPostMessages_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().TwitchPollsPostMessages = checkBoxTwitchPollsPostMessages.Checked;
        }

        private void EnabledEffectsView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is EffectTreeNode && debug)
            {
                EffectTreeNode node = (EffectTreeNode)e.Node;
                node.Effect.RunEffect();
            }
        }

        private void CheckBoxPlayAudioForEffects_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().PlayAudioForEffects = checkBoxPlayAudioForEffects.Checked;
        }

        private string FilterMultiplayerCharacters(string text)
        {
            return Regex.Replace(text, "[^A-Za-z0-9]", "");
        }

        private void UpdateButtonState()
        {
            buttonMultiplayerConnect.Enabled
                = !string.IsNullOrEmpty(textBoxMultiplayerServer.Text)
                && !string.IsNullOrEmpty(textBoxMultiplayerChannel.Text)
                && !string.IsNullOrEmpty(textBoxMultiplayerUsername.Text);
        }

        private void TextBoxMultiplayerServer_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void TextBoxMultiplayerChannel_TextChanged(object sender, EventArgs e)
        {
            textBoxMultiplayerChannel.Text = FilterMultiplayerCharacters(textBoxMultiplayerChannel.Text);
            UpdateButtonState();
        }

        private void TextBoxMultiplayerUsername_TextChanged(object sender, EventArgs e)
        {
            textBoxMultiplayerUsername.Text = FilterMultiplayerCharacters(textBoxMultiplayerUsername.Text);
            UpdateButtonState();
        }

        private void UpdateMultiplayerConnectionState(int state)
        {
            Invoke(new Action(() =>
            {
                if (state == 0) // Not connected
                {
                    textBoxMultiplayerServer.Enabled
                        = textBoxMultiplayerChannel.Enabled
                        = textBoxMultiplayerUsername.Enabled
                        = buttonMultiplayerConnect.Enabled
                        = true;

                    buttonMultiplayerConnect.Text = "Connect";

                    buttonSwitchMode.Enabled = true;
                    buttonMainToggle.Enabled = true;
                    buttonResetMain.Enabled = true;
                    comboBoxMainCooldown.Enabled = true;
                    enabledEffectsView.Enabled = true;
                    textBoxSeed.Enabled = true;
                }
                else if (state == 1) // Connecting...
                {
                    textBoxMultiplayerServer.Enabled
                        = textBoxMultiplayerChannel.Enabled
                        = textBoxMultiplayerUsername.Enabled
                        = buttonMultiplayerConnect.Enabled
                        = false;

                    buttonMultiplayerConnect.Text = "Connecting...";
                }
                else if (state == 2) // Connected
                {
                    textBoxMultiplayerServer.Enabled
                        = textBoxMultiplayerChannel.Enabled
                        = textBoxMultiplayerUsername.Enabled
                        = false;

                    buttonMultiplayerConnect.Enabled = true;
                    buttonMultiplayerConnect.Text = "Disconnect";
                }
            }));
        }

        private void ShowMessageBox(string text, string caption)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(this, text, caption);
            }));
        }

        private void AddToMultiplayerChatHistory(string message)
        {
            Invoke(new Action(() =>
            {
                listBoxMultiplayerChat.Items.Add(message);
                listBoxMultiplayerChat.TopIndex = listBoxMultiplayerChat.Items.Count - 1;
            }));
        }

        private void ClearMultiplayerChatHistory()
        {
            Invoke(new Action(() =>
            {
                listBoxMultiplayerChat.Items.Clear();
            }));
        }

        private void ButtonMultiplayerConnect_Click(object sender, EventArgs e)
        {
            Shared.Multiplayer?.Disconnect();

            if (buttonMultiplayerConnect.Text == "Disconnect")
            {
                UpdateMultiplayerConnectionState(0);
                return;
            }

            ClearMultiplayerChatHistory();

            Shared.Multiplayer = new Multiplayer(
                textBoxMultiplayerServer.Text,
                textBoxMultiplayerChannel.Text,
                textBoxMultiplayerUsername.Text
            );

            UpdateMultiplayerConnectionState(1);

            Shared.Multiplayer.OnConnectionFailed += (_sender, args) =>
            {
                ShowMessageBox("Connection failed - is the server running?", "Error");
                UpdateMultiplayerConnectionState(0);
            };

            Shared.Multiplayer.OnUsernameInUse += (_sender, args) =>
            {
                ShowMessageBox("Username already in use!", "Error");
                UpdateMultiplayerConnectionState(0);
            };

            Shared.Multiplayer.OnConnectionSuccessful += (_sender, args) =>
            {
                ShowMessageBox("Successfully connected!", "Connected");
                AddToMultiplayerChatHistory($"Successfully connected to channel: {textBoxMultiplayerChannel.Text}");
                UpdateMultiplayerConnectionState(2);

                Invoke(new Action(() =>
                {
                    if (!args.IsHost)
                    {
                        SwitchMode(false);

                        buttonSwitchMode.Enabled = false;
                        buttonMainToggle.Enabled = false;
                        buttonResetMain.Enabled = false;
                        comboBoxMainCooldown.Enabled = false;
                        enabledEffectsView.Enabled = false;
                        buttonResetMain.Enabled = false;
                        textBoxSeed.Enabled = false;
                    }

                    labelMultiplayerHost.Text = $"Host: {args.HostUsername}";
                    if (args.IsHost)
                    {
                        labelMultiplayerHost.Text += " (You!)";
                    }
                }));
            };

            Shared.Multiplayer.OnHostLeftChannel += (_sender, args) =>
            {
                ShowMessageBox("Host has left the channel; Disconnected.", "Host Left");
                AddToMultiplayerChatHistory("Host has left the channel; Disconnected.");
                UpdateMultiplayerConnectionState(0);
            };

            Shared.Multiplayer.OnVersionMismatch += (_sender, args) =>
            {
                ShowMessageBox($"Channel is v{args.Version} but you have v{Shared.Version}; Disconnected.", "Version Mismatch");
                AddToMultiplayerChatHistory($"Channel is v{args.Version} but you have v{Shared.Version}; Disconnected.");
                UpdateMultiplayerConnectionState(0);
            };

            Shared.Multiplayer.OnUserJoined += (_sender, args) =>
            {
                AddToMultiplayerChatHistory($"{args.Username} joined!");
            };

            Shared.Multiplayer.OnUserLeft += (_sender, args) =>
            {
                AddToMultiplayerChatHistory($"{args.Username} left!");
            };

            Shared.Multiplayer.OnChatMessage += (_sender, args) =>
            {
                AddToMultiplayerChatHistory($"{args.Username}: {args.Message}");
            };

            Shared.Multiplayer.OnTimeUpdate += (_sender, args) =>
            {
                if (!Shared.Multiplayer.IsHost)
                {
                    WebsocketHandler.INSTANCE.SendTimeToGame(args.Remaining, args.Total);
                }
            };

            Shared.Multiplayer.OnEffect += (_sender, args) =>
            {
                var effect = EffectDatabase.GetByWord(args.Word);
                if (effect != null)
                {
                    if (string.IsNullOrEmpty(args.Voter) || args.Voter == "N/A")
                    {
                        effect.ResetStreamVoter();
                    }
                    else
                    {
                        effect.SetTreamVoter(args.Voter);
                    }
                    EffectDatabase.RunEffect(effect, args.Seed, args.Duration);

                    AddEffectToListBox(effect);
                }
            };

            Shared.Multiplayer.OnVotes += (_sender, args) =>
            {
                string[] effects = args.Effects;
                int[] votes = args.Votes;

                WebsocketHandler.INSTANCE.SendVotes(effects, votes, args.LastChoice);
            };

            Shared.Multiplayer.Connect();
        }

        private void TextBoxMultiplayerChat_TextChanged(object sender, EventArgs e)
        {
            buttonMultiplayerSend.Enabled = Shared.Multiplayer != null && !string.IsNullOrEmpty(textBoxMultiplayerChat.Text);
        }

        private void ButtonMultiplayerSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxMultiplayerChat.Text))
            {
                Shared.Multiplayer?.SendChatMessage(textBoxMultiplayerChat.Text);
                textBoxMultiplayerChat.Text = "";
            }
        }

        private void TextBoxMultiplayerChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBoxMultiplayerChat.Text))
            {
                Shared.Multiplayer?.SendChatMessage(textBoxMultiplayerChat.Text);
                textBoxMultiplayerChat.Text = "";
            }
        }

        private void CheckBoxExperimental_EnableAllEffects_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().Experimental_EnableAllEffects = checkBoxExperimental_EnableAllEffects.Checked;
        }

        private void CheckBoxExperimental_EnableEffectOnAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().Experimental_RunEffectOnAutoStart = checkBoxExperimental_RunEffectOnAutoStart.Checked;
        }

        private void ExperimentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!tabs.TabPages.Contains(tabExperimental))
            {
                tabs.TabPages.Add(tabExperimental);
            }
            experimentalToolStripMenuItem.Visible = false;
        }

        private void ButtonExperimentalRunEffect_Click(object sender, EventArgs e)
        {
            string textInput = textBoxExperimentalEffectName.Text;
            if (string.IsNullOrEmpty(textInput))
            {
                return;
            }

            // Try and get an effect by it's ID
            var effect = EffectDatabase.GetByID(textInput);
            // Try and get an effect by it's ID with "effect_" at the start
            if (effect == null) effect = EffectDatabase.GetByID($"effect_{textInput}");
            // Try and get an effect by it's "cheat" word
            if (effect == null) effect = EffectDatabase.GetByWord(textInput);
            if (effect != null)
            {
                effect.RunEffect();
                return;
            }

            int duration = Config.GetEffectDuration();
            WebsocketHandler.INSTANCE.SendEffectToGame(textBoxExperimentalEffectName.Text, new
            {
                seed = RandomHandler.Next(9999999)
            }, duration);
        }

        private void TextBoxExperimentalEffectName_TextChanged(object sender, EventArgs e)
        {
            Config.Instance().Experimental_EffectName = textBoxExperimentalEffectName.Text;
        }

        private void CheckBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().AutoStart = checkBoxAutoStart.Checked;
        }

        private void CheckBoxStreamEnableRapidFire_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamEnableRapidFire = checkBoxStreamEnableRapidFire.Checked;
        }

        private void CheckBoxStreamMajorityVotes_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamMajorityVotes = checkBoxStreamMajorityVotes.Checked;

            checkBoxStreamEnableMultipleEffects.Enabled = Config.Instance().StreamMajorityVotes;
        }

        private void LinkLabelTwitchGetAccessToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://chaos.lord.moe/");
        }

        private void CheckBoxExperimentalYouTubeConnection_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance().Experimental_YouTubeConnection = checkBoxExperimentalYouTubeConnection.Checked;
        }

        private void TextBoxStreamClientID_TextChanged(object sender, EventArgs e)
        {
            Config.Instance().StreamClientID = textBoxStreamClientID.Text;

            UpdateStreamConnectButtonState();
        }
    }
}
