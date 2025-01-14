namespace GTAChaos.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonMainToggle = new System.Windows.Forms.Button();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.checkBoxShowLastEffectsMain = new System.Windows.Forms.CheckBox();
            this.buttonResetMain = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMainCooldown = new System.Windows.Forms.ComboBox();
            this.listLastEffectsMain = new System.Windows.Forms.ListBox();
            this.tabStream = new System.Windows.Forms.TabPage();
            this.labelStreamClientID = new System.Windows.Forms.Label();
            this.textBoxStreamClientID = new System.Windows.Forms.TextBox();
            this.labelStreamAccessToken = new System.Windows.Forms.Label();
            this.linkLabelTwitchGetAccessToken = new System.Windows.Forms.LinkLabel();
            this.checkBoxStreamCombineVotingMessages = new System.Windows.Forms.CheckBox();
            this.checkBoxTwitchUsePolls = new System.Windows.Forms.CheckBox();
            this.checkBoxStreamMajorityVotes = new System.Windows.Forms.CheckBox();
            this.checkBoxStreamEnableRapidFire = new System.Windows.Forms.CheckBox();
            this.checkBoxStreamEnableMultipleEffects = new System.Windows.Forms.CheckBox();
            this.checkBoxStream3TimesCooldown = new System.Windows.Forms.CheckBox();
            this.buttonResetStream = new System.Windows.Forms.Button();
            this.checkBoxStreamAllowOnlyEnabledEffects = new System.Windows.Forms.CheckBox();
            this.checkBoxShowLastEffectsStream = new System.Windows.Forms.CheckBox();
            this.labelStreamCurrentMode = new System.Windows.Forms.Label();
            this.buttonStreamToggle = new System.Windows.Forms.Button();
            this.comboBoxVotingCooldown = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVotingTime = new System.Windows.Forms.ComboBox();
            this.progressBarStream = new System.Windows.Forms.ProgressBar();
            this.listLastEffectsStream = new System.Windows.Forms.ListBox();
            this.textBoxStreamAccessToken = new System.Windows.Forms.TextBox();
            this.buttonConnectStream = new System.Windows.Forms.Button();
            this.tabPolls = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTwitchPollsChannelPointsCost = new System.Windows.Forms.NumericUpDown();
            this.checkBoxTwitchPollsPostMessages = new System.Windows.Forms.CheckBox();
            this.labelTwitchPollsBitsCost = new System.Windows.Forms.Label();
            this.numericUpDownTwitchPollsBitsCost = new System.Windows.Forms.NumericUpDown();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.labelEffectCooldown = new System.Windows.Forms.Label();
            this.numericUpDownEffectCooldown = new System.Windows.Forms.NumericUpDown();
            this.buttonEffectsToggleAll = new System.Windows.Forms.Button();
            this.enabledEffectsView = new System.Windows.Forms.TreeView();
            this.tabSync = new System.Windows.Forms.TabPage();
            this.buttonSyncSend = new System.Windows.Forms.Button();
            this.textBoxSyncChat = new System.Windows.Forms.TextBox();
            this.listBoxSyncChat = new System.Windows.Forms.ListBox();
            this.labelSyncHost = new System.Windows.Forms.Label();
            this.textBoxSyncUsername = new System.Windows.Forms.TextBox();
            this.labelSyncUsername = new System.Windows.Forms.Label();
            this.labelSyncChannel = new System.Windows.Forms.Label();
            this.textBoxSyncChannel = new System.Windows.Forms.TextBox();
            this.labelSyncServer = new System.Windows.Forms.Label();
            this.textBoxSyncServer = new System.Windows.Forms.TextBox();
            this.buttonSyncConnect = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSettingsStreamMode = new System.Windows.Forms.ComboBox();
            this.checkBoxSettingsCheckForUpdatesAtLaunch = new System.Windows.Forms.CheckBox();
            this.buttonRestartWebsocket = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericWebsocketPort = new System.Windows.Forms.NumericUpDown();
            this.checkBoxStreamHideVotingEffectsIngame = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.tabExperimental = new System.Windows.Forms.TabPage();
            this.buttonExperimentalRunEffect = new System.Windows.Forms.Button();
            this.textBoxExperimentalEffectName = new System.Windows.Forms.TextBox();
            this.checkBoxExperimental_RunEffectOnAutoStart = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viceCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanAndreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.buttonSwitchMode = new System.Windows.Forms.Button();
            this.buttonExperimentalClearActiveEffects = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabStream.SuspendLayout();
            this.tabPolls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTwitchPollsChannelPointsCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTwitchPollsBitsCost)).BeginInit();
            this.tabEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEffectCooldown)).BeginInit();
            this.tabSync.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWebsocketPort)).BeginInit();
            this.tabExperimental.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMainToggle
            // 
            this.buttonMainToggle.Location = new System.Drawing.Point(6, 6);
            this.buttonMainToggle.Name = "buttonMainToggle";
            this.buttonMainToggle.Size = new System.Drawing.Size(94, 23);
            this.buttonMainToggle.TabIndex = 0;
            this.buttonMainToggle.Text = "Start / Resume";
            this.buttonMainToggle.UseVisualStyleBackColor = true;
            this.buttonMainToggle.Click += new System.EventHandler(this.ButtonMainToggle_Click);
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(206, 6);
            this.progressBarMain.Maximum = 60;
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(338, 23);
            this.progressBarMain.Step = 1;
            this.progressBarMain.TabIndex = 1;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMain);
            this.tabs.Controls.Add(this.tabStream);
            this.tabs.Controls.Add(this.tabPolls);
            this.tabs.Controls.Add(this.tabEffects);
            this.tabs.Controls.Add(this.tabSync);
            this.tabs.Controls.Add(this.tabSettings);
            this.tabs.Controls.Add(this.tabExperimental);
            this.tabs.Location = new System.Drawing.Point(0, 41);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(560, 319);
            this.tabs.TabIndex = 4;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.Transparent;
            this.tabMain.Controls.Add(this.checkBoxShowLastEffectsMain);
            this.tabMain.Controls.Add(this.buttonResetMain);
            this.tabMain.Controls.Add(this.label2);
            this.tabMain.Controls.Add(this.comboBoxMainCooldown);
            this.tabMain.Controls.Add(this.buttonMainToggle);
            this.tabMain.Controls.Add(this.listLastEffectsMain);
            this.tabMain.Controls.Add(this.progressBarMain);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(552, 293);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // checkBoxShowLastEffectsMain
            // 
            this.checkBoxShowLastEffectsMain.AutoSize = true;
            this.checkBoxShowLastEffectsMain.Checked = true;
            this.checkBoxShowLastEffectsMain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowLastEffectsMain.Location = new System.Drawing.Point(6, 111);
            this.checkBoxShowLastEffectsMain.Name = "checkBoxShowLastEffectsMain";
            this.checkBoxShowLastEffectsMain.Size = new System.Drawing.Size(112, 17);
            this.checkBoxShowLastEffectsMain.TabIndex = 8;
            this.checkBoxShowLastEffectsMain.Text = "Show Last Effects";
            this.checkBoxShowLastEffectsMain.UseVisualStyleBackColor = true;
            this.checkBoxShowLastEffectsMain.CheckedChanged += new System.EventHandler(this.CheckBoxShowLastEffectsMain_CheckedChanged);
            // 
            // buttonResetMain
            // 
            this.buttonResetMain.Location = new System.Drawing.Point(106, 6);
            this.buttonResetMain.Name = "buttonResetMain";
            this.buttonResetMain.Size = new System.Drawing.Size(94, 23);
            this.buttonResetMain.TabIndex = 7;
            this.buttonResetMain.Text = "Reset";
            this.buttonResetMain.UseVisualStyleBackColor = true;
            this.buttonResetMain.Click += new System.EventHandler(this.ButtonResetMain_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cooldown:";
            // 
            // comboBoxMainCooldown
            // 
            this.comboBoxMainCooldown.FormattingEnabled = true;
            this.comboBoxMainCooldown.Location = new System.Drawing.Point(423, 35);
            this.comboBoxMainCooldown.Name = "comboBoxMainCooldown";
            this.comboBoxMainCooldown.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMainCooldown.TabIndex = 5;
            this.comboBoxMainCooldown.SelectedIndexChanged += new System.EventHandler(this.MainCooldownComboBox_SelectedIndexChanged);
            // 
            // listLastEffectsMain
            // 
            this.listLastEffectsMain.FormattingEnabled = true;
            this.listLastEffectsMain.Location = new System.Drawing.Point(6, 134);
            this.listLastEffectsMain.Name = "listLastEffectsMain";
            this.listLastEffectsMain.Size = new System.Drawing.Size(538, 147);
            this.listLastEffectsMain.TabIndex = 4;
            // 
            // tabStream
            // 
            this.tabStream.BackColor = System.Drawing.Color.Transparent;
            this.tabStream.Controls.Add(this.labelStreamClientID);
            this.tabStream.Controls.Add(this.textBoxStreamClientID);
            this.tabStream.Controls.Add(this.labelStreamAccessToken);
            this.tabStream.Controls.Add(this.linkLabelTwitchGetAccessToken);
            this.tabStream.Controls.Add(this.checkBoxStreamCombineVotingMessages);
            this.tabStream.Controls.Add(this.checkBoxTwitchUsePolls);
            this.tabStream.Controls.Add(this.checkBoxStreamMajorityVotes);
            this.tabStream.Controls.Add(this.checkBoxStreamEnableRapidFire);
            this.tabStream.Controls.Add(this.checkBoxStreamEnableMultipleEffects);
            this.tabStream.Controls.Add(this.checkBoxStream3TimesCooldown);
            this.tabStream.Controls.Add(this.buttonResetStream);
            this.tabStream.Controls.Add(this.checkBoxStreamAllowOnlyEnabledEffects);
            this.tabStream.Controls.Add(this.checkBoxShowLastEffectsStream);
            this.tabStream.Controls.Add(this.labelStreamCurrentMode);
            this.tabStream.Controls.Add(this.buttonStreamToggle);
            this.tabStream.Controls.Add(this.comboBoxVotingCooldown);
            this.tabStream.Controls.Add(this.label7);
            this.tabStream.Controls.Add(this.label6);
            this.tabStream.Controls.Add(this.comboBoxVotingTime);
            this.tabStream.Controls.Add(this.progressBarStream);
            this.tabStream.Controls.Add(this.listLastEffectsStream);
            this.tabStream.Controls.Add(this.textBoxStreamAccessToken);
            this.tabStream.Controls.Add(this.buttonConnectStream);
            this.tabStream.Location = new System.Drawing.Point(4, 22);
            this.tabStream.Name = "tabStream";
            this.tabStream.Size = new System.Drawing.Size(552, 293);
            this.tabStream.TabIndex = 2;
            this.tabStream.Text = "Stream";
            // 
            // labelStreamClientID
            // 
            this.labelStreamClientID.AutoSize = true;
            this.labelStreamClientID.Location = new System.Drawing.Point(8, 10);
            this.labelStreamClientID.Name = "labelStreamClientID";
            this.labelStreamClientID.Size = new System.Drawing.Size(50, 13);
            this.labelStreamClientID.TabIndex = 33;
            this.labelStreamClientID.Text = "Client ID:";
            // 
            // textBoxStreamClientID
            // 
            this.textBoxStreamClientID.Location = new System.Drawing.Point(93, 7);
            this.textBoxStreamClientID.Name = "textBoxStreamClientID";
            this.textBoxStreamClientID.PasswordChar = '*';
            this.textBoxStreamClientID.Size = new System.Drawing.Size(125, 20);
            this.textBoxStreamClientID.TabIndex = 32;
            this.textBoxStreamClientID.TextChanged += new System.EventHandler(this.TextBoxStreamClientID_TextChanged);
            // 
            // labelStreamAccessToken
            // 
            this.labelStreamAccessToken.AutoSize = true;
            this.labelStreamAccessToken.Location = new System.Drawing.Point(8, 35);
            this.labelStreamAccessToken.Name = "labelStreamAccessToken";
            this.labelStreamAccessToken.Size = new System.Drawing.Size(79, 13);
            this.labelStreamAccessToken.TabIndex = 31;
            this.labelStreamAccessToken.Text = "Access Token:";
            // 
            // linkLabelTwitchGetAccessToken
            // 
            this.linkLabelTwitchGetAccessToken.AutoSize = true;
            this.linkLabelTwitchGetAccessToken.Location = new System.Drawing.Point(224, 10);
            this.linkLabelTwitchGetAccessToken.Name = "linkLabelTwitchGetAccessToken";
            this.linkLabelTwitchGetAccessToken.Size = new System.Drawing.Size(131, 13);
            this.linkLabelTwitchGetAccessToken.TabIndex = 30;
            this.linkLabelTwitchGetAccessToken.TabStop = true;
            this.linkLabelTwitchGetAccessToken.Text = "Get Twitch Access Token";
            this.linkLabelTwitchGetAccessToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTwitchGetAccessToken_LinkClicked);
            // 
            // checkBoxStreamCombineVotingMessages
            // 
            this.checkBoxStreamCombineVotingMessages.AutoSize = true;
            this.checkBoxStreamCombineVotingMessages.Location = new System.Drawing.Point(124, 121);
            this.checkBoxStreamCombineVotingMessages.Name = "checkBoxStreamCombineVotingMessages";
            this.checkBoxStreamCombineVotingMessages.Size = new System.Drawing.Size(151, 17);
            this.checkBoxStreamCombineVotingMessages.TabIndex = 29;
            this.checkBoxStreamCombineVotingMessages.Text = "Combine Voting Messages";
            this.checkBoxStreamCombineVotingMessages.UseVisualStyleBackColor = true;
            // 
            // checkBoxTwitchUsePolls
            // 
            this.checkBoxTwitchUsePolls.AutoSize = true;
            this.checkBoxTwitchUsePolls.Location = new System.Drawing.Point(391, 64);
            this.checkBoxTwitchUsePolls.Name = "checkBoxTwitchUsePolls";
            this.checkBoxTwitchUsePolls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxTwitchUsePolls.Size = new System.Drawing.Size(153, 17);
            this.checkBoxTwitchUsePolls.TabIndex = 28;
            this.checkBoxTwitchUsePolls.Text = "Use Twitch Polls For Votes";
            this.toolTipHandler.SetToolTip(this.checkBoxTwitchUsePolls, "This will force majority voting,\r\nno matter what the checkbox is.\r\nThere is no in" +
        "formation on\r\nwhich user voted for which vote.");
            this.checkBoxTwitchUsePolls.UseVisualStyleBackColor = true;
            this.checkBoxTwitchUsePolls.CheckedChanged += new System.EventHandler(this.CheckBoxTwitchUsePolls_CheckedChanged);
            // 
            // checkBoxStreamMajorityVotes
            // 
            this.checkBoxStreamMajorityVotes.AutoSize = true;
            this.checkBoxStreamMajorityVotes.Checked = true;
            this.checkBoxStreamMajorityVotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStreamMajorityVotes.Location = new System.Drawing.Point(452, 116);
            this.checkBoxStreamMajorityVotes.Name = "checkBoxStreamMajorityVotes";
            this.checkBoxStreamMajorityVotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStreamMajorityVotes.Size = new System.Drawing.Size(92, 17);
            this.checkBoxStreamMajorityVotes.TabIndex = 27;
            this.checkBoxStreamMajorityVotes.Text = "Majority Votes";
            this.toolTipHandler.SetToolTip(this.checkBoxStreamMajorityVotes, "This will force majority voting,\r\nno matter what the checkbox is.\r\nThere is no in" +
        "formation on\r\nwhich user voted for which vote.");
            this.checkBoxStreamMajorityVotes.UseVisualStyleBackColor = true;
            this.checkBoxStreamMajorityVotes.CheckedChanged += new System.EventHandler(this.CheckBoxStreamMajorityVotes_CheckedChanged);
            // 
            // checkBoxStreamEnableRapidFire
            // 
            this.checkBoxStreamEnableRapidFire.AutoSize = true;
            this.checkBoxStreamEnableRapidFire.Checked = true;
            this.checkBoxStreamEnableRapidFire.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStreamEnableRapidFire.Location = new System.Drawing.Point(434, 185);
            this.checkBoxStreamEnableRapidFire.Name = "checkBoxStreamEnableRapidFire";
            this.checkBoxStreamEnableRapidFire.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStreamEnableRapidFire.Size = new System.Drawing.Size(110, 17);
            this.checkBoxStreamEnableRapidFire.TabIndex = 26;
            this.checkBoxStreamEnableRapidFire.Text = "Enable Rapid-Fire";
            this.checkBoxStreamEnableRapidFire.UseVisualStyleBackColor = true;
            this.checkBoxStreamEnableRapidFire.CheckedChanged += new System.EventHandler(this.CheckBoxStreamEnableRapidFire_CheckedChanged);
            // 
            // checkBoxStreamEnableMultipleEffects
            // 
            this.checkBoxStreamEnableMultipleEffects.AutoSize = true;
            this.checkBoxStreamEnableMultipleEffects.Location = new System.Drawing.Point(418, 139);
            this.checkBoxStreamEnableMultipleEffects.Name = "checkBoxStreamEnableMultipleEffects";
            this.checkBoxStreamEnableMultipleEffects.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStreamEnableMultipleEffects.Size = new System.Drawing.Size(126, 17);
            this.checkBoxStreamEnableMultipleEffects.TabIndex = 25;
            this.checkBoxStreamEnableMultipleEffects.Text = "Allow Multiple Effects";
            this.checkBoxStreamEnableMultipleEffects.UseVisualStyleBackColor = true;
            this.checkBoxStreamEnableMultipleEffects.CheckedChanged += new System.EventHandler(this.CheckBoxStreamEnableMultipleEffects_CheckedChanged);
            // 
            // checkBoxStream3TimesCooldown
            // 
            this.checkBoxStream3TimesCooldown.AutoSize = true;
            this.checkBoxStream3TimesCooldown.Checked = true;
            this.checkBoxStream3TimesCooldown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStream3TimesCooldown.Location = new System.Drawing.Point(457, 162);
            this.checkBoxStream3TimesCooldown.Name = "checkBoxStream3TimesCooldown";
            this.checkBoxStream3TimesCooldown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStream3TimesCooldown.Size = new System.Drawing.Size(87, 17);
            this.checkBoxStream3TimesCooldown.TabIndex = 24;
            this.checkBoxStream3TimesCooldown.Text = "3x Cooldown";
            this.toolTipHandler.SetToolTip(this.checkBoxStream3TimesCooldown, "When enabled effects will have 3x their cooldown.\r\n(Cooldown in this case is the " +
        "Voting Time + Voting Cooldown)");
            this.checkBoxStream3TimesCooldown.UseVisualStyleBackColor = true;
            this.checkBoxStream3TimesCooldown.CheckedChanged += new System.EventHandler(this.CheckBoxStream3TimesCooldown_CheckedChanged);
            // 
            // buttonResetStream
            // 
            this.buttonResetStream.Enabled = false;
            this.buttonResetStream.Location = new System.Drawing.Point(477, 7);
            this.buttonResetStream.Name = "buttonResetStream";
            this.buttonResetStream.Size = new System.Drawing.Size(67, 23);
            this.buttonResetStream.TabIndex = 21;
            this.buttonResetStream.Text = "Reset";
            this.buttonResetStream.UseVisualStyleBackColor = true;
            this.buttonResetStream.Click += new System.EventHandler(this.ButtonResetStream_Click);
            // 
            // checkBoxStreamAllowOnlyEnabledEffects
            // 
            this.checkBoxStreamAllowOnlyEnabledEffects.AutoSize = true;
            this.checkBoxStreamAllowOnlyEnabledEffects.Location = new System.Drawing.Point(396, 207);
            this.checkBoxStreamAllowOnlyEnabledEffects.Name = "checkBoxStreamAllowOnlyEnabledEffects";
            this.checkBoxStreamAllowOnlyEnabledEffects.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStreamAllowOnlyEnabledEffects.Size = new System.Drawing.Size(148, 17);
            this.checkBoxStreamAllowOnlyEnabledEffects.TabIndex = 19;
            this.checkBoxStreamAllowOnlyEnabledEffects.Text = "Only Enabled Effects (RF)";
            this.toolTipHandler.SetToolTip(this.checkBoxStreamAllowOnlyEnabledEffects, "Only allow effects that are enabled\r\nin the currently active preset during Rapid-" +
        "Fire.");
            this.checkBoxStreamAllowOnlyEnabledEffects.UseVisualStyleBackColor = true;
            this.checkBoxStreamAllowOnlyEnabledEffects.CheckedChanged += new System.EventHandler(this.CheckBoxStreamAllowOnlyEnabledEffects_CheckedChanged);
            // 
            // checkBoxShowLastEffectsStream
            // 
            this.checkBoxShowLastEffectsStream.AutoSize = true;
            this.checkBoxShowLastEffectsStream.Checked = true;
            this.checkBoxShowLastEffectsStream.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowLastEffectsStream.Location = new System.Drawing.Point(8, 121);
            this.checkBoxShowLastEffectsStream.Name = "checkBoxShowLastEffectsStream";
            this.checkBoxShowLastEffectsStream.Size = new System.Drawing.Size(112, 17);
            this.checkBoxShowLastEffectsStream.TabIndex = 18;
            this.checkBoxShowLastEffectsStream.Text = "Show Last Effects";
            this.checkBoxShowLastEffectsStream.UseVisualStyleBackColor = true;
            this.checkBoxShowLastEffectsStream.CheckedChanged += new System.EventHandler(this.CheckBoxShowLastEffectsStream_CheckedChanged);
            // 
            // labelStreamCurrentMode
            // 
            this.labelStreamCurrentMode.AutoSize = true;
            this.labelStreamCurrentMode.Location = new System.Drawing.Point(8, 71);
            this.labelStreamCurrentMode.Name = "labelStreamCurrentMode";
            this.labelStreamCurrentMode.Size = new System.Drawing.Size(124, 13);
            this.labelStreamCurrentMode.TabIndex = 17;
            this.labelStreamCurrentMode.Text = "Current Mode: Cooldown";
            // 
            // buttonStreamToggle
            // 
            this.buttonStreamToggle.Enabled = false;
            this.buttonStreamToggle.Location = new System.Drawing.Point(368, 7);
            this.buttonStreamToggle.Name = "buttonStreamToggle";
            this.buttonStreamToggle.Size = new System.Drawing.Size(103, 23);
            this.buttonStreamToggle.TabIndex = 15;
            this.buttonStreamToggle.Text = "Start / Resume";
            this.buttonStreamToggle.UseVisualStyleBackColor = true;
            this.buttonStreamToggle.Click += new System.EventHandler(this.ButtonStreamToggle_Click);
            // 
            // comboBoxVotingCooldown
            // 
            this.comboBoxVotingCooldown.FormattingEnabled = true;
            this.comboBoxVotingCooldown.Location = new System.Drawing.Point(389, 257);
            this.comboBoxVotingCooldown.Name = "comboBoxVotingCooldown";
            this.comboBoxVotingCooldown.Size = new System.Drawing.Size(155, 21);
            this.comboBoxVotingCooldown.TabIndex = 14;
            this.comboBoxVotingCooldown.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVotingCooldown_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Voting Cooldown:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Voting Time:";
            // 
            // comboBoxVotingTime
            // 
            this.comboBoxVotingTime.FormattingEnabled = true;
            this.comboBoxVotingTime.Location = new System.Drawing.Point(389, 230);
            this.comboBoxVotingTime.Name = "comboBoxVotingTime";
            this.comboBoxVotingTime.Size = new System.Drawing.Size(155, 21);
            this.comboBoxVotingTime.TabIndex = 11;
            this.comboBoxVotingTime.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVotingTime_SelectedIndexChanged);
            // 
            // progressBarStream
            // 
            this.progressBarStream.Location = new System.Drawing.Point(8, 87);
            this.progressBarStream.Name = "progressBarStream";
            this.progressBarStream.Size = new System.Drawing.Size(536, 23);
            this.progressBarStream.TabIndex = 10;
            // 
            // listLastEffectsStream
            // 
            this.listLastEffectsStream.FormattingEnabled = true;
            this.listLastEffectsStream.Location = new System.Drawing.Point(8, 144);
            this.listLastEffectsStream.Name = "listLastEffectsStream";
            this.listLastEffectsStream.Size = new System.Drawing.Size(273, 134);
            this.listLastEffectsStream.TabIndex = 8;
            // 
            // textBoxStreamAccessToken
            // 
            this.textBoxStreamAccessToken.Location = new System.Drawing.Point(93, 32);
            this.textBoxStreamAccessToken.Name = "textBoxStreamAccessToken";
            this.textBoxStreamAccessToken.PasswordChar = '*';
            this.textBoxStreamAccessToken.Size = new System.Drawing.Size(125, 20);
            this.textBoxStreamAccessToken.TabIndex = 3;
            this.textBoxStreamAccessToken.TextChanged += new System.EventHandler(this.TextBoxOAuth_TextChanged);
            // 
            // buttonConnectStream
            // 
            this.buttonConnectStream.Enabled = false;
            this.buttonConnectStream.Location = new System.Drawing.Point(224, 32);
            this.buttonConnectStream.Name = "buttonConnectStream";
            this.buttonConnectStream.Size = new System.Drawing.Size(121, 22);
            this.buttonConnectStream.TabIndex = 1;
            this.buttonConnectStream.Text = "Connect to Stream";
            this.buttonConnectStream.UseVisualStyleBackColor = true;
            this.buttonConnectStream.Click += new System.EventHandler(this.ButtonConnectStream_Click);
            // 
            // tabPolls
            // 
            this.tabPolls.BackColor = System.Drawing.Color.Transparent;
            this.tabPolls.Controls.Add(this.label1);
            this.tabPolls.Controls.Add(this.numericUpDownTwitchPollsChannelPointsCost);
            this.tabPolls.Controls.Add(this.checkBoxTwitchPollsPostMessages);
            this.tabPolls.Controls.Add(this.labelTwitchPollsBitsCost);
            this.tabPolls.Controls.Add(this.numericUpDownTwitchPollsBitsCost);
            this.tabPolls.Location = new System.Drawing.Point(4, 22);
            this.tabPolls.Name = "tabPolls";
            this.tabPolls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPolls.Size = new System.Drawing.Size(552, 293);
            this.tabPolls.TabIndex = 5;
            this.tabPolls.Text = "Polls";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Channel Points Cost For Voting (0 = Disabled)";
            // 
            // numericUpDownTwitchPollsChannelPointsCost
            // 
            this.numericUpDownTwitchPollsChannelPointsCost.Location = new System.Drawing.Point(233, 56);
            this.numericUpDownTwitchPollsChannelPointsCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTwitchPollsChannelPointsCost.Name = "numericUpDownTwitchPollsChannelPointsCost";
            this.numericUpDownTwitchPollsChannelPointsCost.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownTwitchPollsChannelPointsCost.TabIndex = 7;
            this.numericUpDownTwitchPollsChannelPointsCost.ValueChanged += new System.EventHandler(this.NumericUpDownTwitchPollsChannelPointsCost_ValueChanged);
            // 
            // checkBoxTwitchPollsPostMessages
            // 
            this.checkBoxTwitchPollsPostMessages.AutoSize = true;
            this.checkBoxTwitchPollsPostMessages.Location = new System.Drawing.Point(8, 6);
            this.checkBoxTwitchPollsPostMessages.Name = "checkBoxTwitchPollsPostMessages";
            this.checkBoxTwitchPollsPostMessages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxTwitchPollsPostMessages.Size = new System.Drawing.Size(148, 17);
            this.checkBoxTwitchPollsPostMessages.TabIndex = 6;
            this.checkBoxTwitchPollsPostMessages.Text = "Post Vote Options In Chat";
            this.checkBoxTwitchPollsPostMessages.UseVisualStyleBackColor = true;
            this.checkBoxTwitchPollsPostMessages.CheckedChanged += new System.EventHandler(this.CheckBoxTwitchPollsPostMessages_CheckedChanged);
            // 
            // labelTwitchPollsBitsCost
            // 
            this.labelTwitchPollsBitsCost.AutoSize = true;
            this.labelTwitchPollsBitsCost.Location = new System.Drawing.Point(6, 35);
            this.labelTwitchPollsBitsCost.Name = "labelTwitchPollsBitsCost";
            this.labelTwitchPollsBitsCost.Size = new System.Drawing.Size(167, 13);
            this.labelTwitchPollsBitsCost.TabIndex = 3;
            this.labelTwitchPollsBitsCost.Text = "Bits Cost For Voting (0 = Disabled)";
            // 
            // numericUpDownTwitchPollsBitsCost
            // 
            this.numericUpDownTwitchPollsBitsCost.Location = new System.Drawing.Point(233, 33);
            this.numericUpDownTwitchPollsBitsCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTwitchPollsBitsCost.Name = "numericUpDownTwitchPollsBitsCost";
            this.numericUpDownTwitchPollsBitsCost.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownTwitchPollsBitsCost.TabIndex = 0;
            this.numericUpDownTwitchPollsBitsCost.ValueChanged += new System.EventHandler(this.NumericUpDownTwitchPollsBitsCost_ValueChanged);
            // 
            // tabEffects
            // 
            this.tabEffects.BackColor = System.Drawing.Color.Transparent;
            this.tabEffects.Controls.Add(this.labelEffectCooldown);
            this.tabEffects.Controls.Add(this.numericUpDownEffectCooldown);
            this.tabEffects.Controls.Add(this.buttonEffectsToggleAll);
            this.tabEffects.Controls.Add(this.enabledEffectsView);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Padding = new System.Windows.Forms.Padding(3);
            this.tabEffects.Size = new System.Drawing.Size(552, 293);
            this.tabEffects.TabIndex = 1;
            this.tabEffects.Text = "Effects";
            // 
            // labelEffectCooldown
            // 
            this.labelEffectCooldown.AutoSize = true;
            this.labelEffectCooldown.Location = new System.Drawing.Point(385, 264);
            this.labelEffectCooldown.Name = "labelEffectCooldown";
            this.labelEffectCooldown.Size = new System.Drawing.Size(88, 13);
            this.labelEffectCooldown.TabIndex = 20;
            this.labelEffectCooldown.Text = "Effect Cooldown:";
            // 
            // numericUpDownEffectCooldown
            // 
            this.numericUpDownEffectCooldown.Location = new System.Drawing.Point(479, 262);
            this.numericUpDownEffectCooldown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownEffectCooldown.Name = "numericUpDownEffectCooldown";
            this.numericUpDownEffectCooldown.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownEffectCooldown.TabIndex = 19;
            this.numericUpDownEffectCooldown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownEffectCooldown.ValueChanged += new System.EventHandler(this.NumericUpDownEffectCooldown_ValueChanged);
            // 
            // buttonEffectsToggleAll
            // 
            this.buttonEffectsToggleAll.Location = new System.Drawing.Point(6, 259);
            this.buttonEffectsToggleAll.Name = "buttonEffectsToggleAll";
            this.buttonEffectsToggleAll.Size = new System.Drawing.Size(277, 23);
            this.buttonEffectsToggleAll.TabIndex = 7;
            this.buttonEffectsToggleAll.Text = "Toggle All";
            this.buttonEffectsToggleAll.UseVisualStyleBackColor = true;
            this.buttonEffectsToggleAll.Click += new System.EventHandler(this.ButtonEffectsToggleAll_Click);
            // 
            // enabledEffectsView
            // 
            this.enabledEffectsView.CheckBoxes = true;
            this.enabledEffectsView.Location = new System.Drawing.Point(6, 6);
            this.enabledEffectsView.Name = "enabledEffectsView";
            this.enabledEffectsView.Size = new System.Drawing.Size(538, 247);
            this.enabledEffectsView.TabIndex = 3;
            this.enabledEffectsView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.EnabledEffectsView_AfterCheck);
            this.enabledEffectsView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.EnabledEffectsView_NodeMouseDoubleClick);
            // 
            // tabSync
            // 
            this.tabSync.BackColor = System.Drawing.Color.Transparent;
            this.tabSync.Controls.Add(this.buttonSyncSend);
            this.tabSync.Controls.Add(this.textBoxSyncChat);
            this.tabSync.Controls.Add(this.listBoxSyncChat);
            this.tabSync.Controls.Add(this.labelSyncHost);
            this.tabSync.Controls.Add(this.textBoxSyncUsername);
            this.tabSync.Controls.Add(this.labelSyncUsername);
            this.tabSync.Controls.Add(this.labelSyncChannel);
            this.tabSync.Controls.Add(this.textBoxSyncChannel);
            this.tabSync.Controls.Add(this.labelSyncServer);
            this.tabSync.Controls.Add(this.textBoxSyncServer);
            this.tabSync.Controls.Add(this.buttonSyncConnect);
            this.tabSync.Location = new System.Drawing.Point(4, 22);
            this.tabSync.Name = "tabSync";
            this.tabSync.Padding = new System.Windows.Forms.Padding(3);
            this.tabSync.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabSync.Size = new System.Drawing.Size(552, 293);
            this.tabSync.TabIndex = 6;
            this.tabSync.Text = "Sync";
            // 
            // buttonSyncSend
            // 
            this.buttonSyncSend.Enabled = false;
            this.buttonSyncSend.Location = new System.Drawing.Point(457, 260);
            this.buttonSyncSend.Name = "buttonSyncSend";
            this.buttonSyncSend.Size = new System.Drawing.Size(87, 22);
            this.buttonSyncSend.TabIndex = 10;
            this.buttonSyncSend.Text = "Send";
            this.buttonSyncSend.UseVisualStyleBackColor = true;
            this.buttonSyncSend.Click += new System.EventHandler(this.ButtonSyncSend_Click);
            // 
            // textBoxSyncChat
            // 
            this.textBoxSyncChat.Location = new System.Drawing.Point(6, 261);
            this.textBoxSyncChat.MaxLength = 128;
            this.textBoxSyncChat.Name = "textBoxSyncChat";
            this.textBoxSyncChat.Size = new System.Drawing.Size(445, 20);
            this.textBoxSyncChat.TabIndex = 9;
            this.textBoxSyncChat.TextChanged += new System.EventHandler(this.TextBoxSyncChat_TextChanged);
            this.textBoxSyncChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSyncChat_KeyDown);
            // 
            // listBoxSyncChat
            // 
            this.listBoxSyncChat.FormattingEnabled = true;
            this.listBoxSyncChat.Location = new System.Drawing.Point(6, 95);
            this.listBoxSyncChat.Name = "listBoxSyncChat";
            this.listBoxSyncChat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxSyncChat.Size = new System.Drawing.Size(538, 160);
            this.listBoxSyncChat.TabIndex = 8;
            // 
            // labelSyncHost
            // 
            this.labelSyncHost.AutoSize = true;
            this.labelSyncHost.Location = new System.Drawing.Point(404, 9);
            this.labelSyncHost.Name = "labelSyncHost";
            this.labelSyncHost.Size = new System.Drawing.Size(87, 13);
            this.labelSyncHost.TabIndex = 7;
            this.labelSyncHost.Text = "Not connected...";
            // 
            // textBoxSyncUsername
            // 
            this.textBoxSyncUsername.Location = new System.Drawing.Point(70, 32);
            this.textBoxSyncUsername.MaxLength = 16;
            this.textBoxSyncUsername.Name = "textBoxSyncUsername";
            this.textBoxSyncUsername.Size = new System.Drawing.Size(328, 20);
            this.textBoxSyncUsername.TabIndex = 2;
            this.textBoxSyncUsername.TextChanged += new System.EventHandler(this.TextBoxSyncUsername_TextChanged);
            // 
            // labelSyncUsername
            // 
            this.labelSyncUsername.AutoSize = true;
            this.labelSyncUsername.Location = new System.Drawing.Point(8, 35);
            this.labelSyncUsername.Name = "labelSyncUsername";
            this.labelSyncUsername.Size = new System.Drawing.Size(58, 13);
            this.labelSyncUsername.TabIndex = 5;
            this.labelSyncUsername.Text = "Username:";
            // 
            // labelSyncChannel
            // 
            this.labelSyncChannel.AutoSize = true;
            this.labelSyncChannel.Location = new System.Drawing.Point(17, 61);
            this.labelSyncChannel.Name = "labelSyncChannel";
            this.labelSyncChannel.Size = new System.Drawing.Size(49, 13);
            this.labelSyncChannel.TabIndex = 4;
            this.labelSyncChannel.Text = "Channel:";
            // 
            // textBoxSyncChannel
            // 
            this.textBoxSyncChannel.Location = new System.Drawing.Point(70, 58);
            this.textBoxSyncChannel.MaxLength = 16;
            this.textBoxSyncChannel.Name = "textBoxSyncChannel";
            this.textBoxSyncChannel.Size = new System.Drawing.Size(328, 20);
            this.textBoxSyncChannel.TabIndex = 3;
            this.textBoxSyncChannel.TextChanged += new System.EventHandler(this.TextBoxSyncChannel_TextChanged);
            // 
            // labelSyncServer
            // 
            this.labelSyncServer.AutoSize = true;
            this.labelSyncServer.Location = new System.Drawing.Point(25, 9);
            this.labelSyncServer.Name = "labelSyncServer";
            this.labelSyncServer.Size = new System.Drawing.Size(41, 13);
            this.labelSyncServer.TabIndex = 2;
            this.labelSyncServer.Text = "Server:";
            // 
            // textBoxSyncServer
            // 
            this.textBoxSyncServer.Location = new System.Drawing.Point(70, 6);
            this.textBoxSyncServer.Name = "textBoxSyncServer";
            this.textBoxSyncServer.Size = new System.Drawing.Size(328, 20);
            this.textBoxSyncServer.TabIndex = 1;
            this.textBoxSyncServer.TextChanged += new System.EventHandler(this.TextBoxSyncServer_TextChanged);
            // 
            // buttonSyncConnect
            // 
            this.buttonSyncConnect.Enabled = false;
            this.buttonSyncConnect.Location = new System.Drawing.Point(404, 31);
            this.buttonSyncConnect.Name = "buttonSyncConnect";
            this.buttonSyncConnect.Size = new System.Drawing.Size(140, 22);
            this.buttonSyncConnect.TabIndex = 4;
            this.buttonSyncConnect.Text = "Connect";
            this.buttonSyncConnect.UseVisualStyleBackColor = true;
            this.buttonSyncConnect.Click += new System.EventHandler(this.ButtonSyncConnect_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.Transparent;
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.comboBoxSettingsStreamMode);
            this.tabSettings.Controls.Add(this.checkBoxSettingsCheckForUpdatesAtLaunch);
            this.tabSettings.Controls.Add(this.buttonRestartWebsocket);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.numericWebsocketPort);
            this.tabSettings.Controls.Add(this.checkBoxStreamHideVotingEffectsIngame);
            this.tabSettings.Controls.Add(this.label8);
            this.tabSettings.Controls.Add(this.textBoxSeed);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(552, 293);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Stream Mode:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxSettingsStreamMode
            // 
            this.comboBoxSettingsStreamMode.FormattingEnabled = true;
            this.comboBoxSettingsStreamMode.Location = new System.Drawing.Point(87, 96);
            this.comboBoxSettingsStreamMode.Name = "comboBoxSettingsStreamMode";
            this.comboBoxSettingsStreamMode.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSettingsStreamMode.TabIndex = 25;
            this.comboBoxSettingsStreamMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxSettingsStreamMode_SelectedIndexChanged);
            // 
            // checkBoxSettingsCheckForUpdatesAtLaunch
            // 
            this.checkBoxSettingsCheckForUpdatesAtLaunch.AutoSize = true;
            this.checkBoxSettingsCheckForUpdatesAtLaunch.Checked = true;
            this.checkBoxSettingsCheckForUpdatesAtLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSettingsCheckForUpdatesAtLaunch.Location = new System.Drawing.Point(9, 32);
            this.checkBoxSettingsCheckForUpdatesAtLaunch.Name = "checkBoxSettingsCheckForUpdatesAtLaunch";
            this.checkBoxSettingsCheckForUpdatesAtLaunch.Size = new System.Drawing.Size(170, 17);
            this.checkBoxSettingsCheckForUpdatesAtLaunch.TabIndex = 24;
            this.checkBoxSettingsCheckForUpdatesAtLaunch.Text = "Check For Updates At Launch";
            this.toolTipHandler.SetToolTip(this.checkBoxSettingsCheckForUpdatesAtLaunch, "Some effects play a sound clip when\r\nthey get activated. Check this to have\r\nthem" +
        " play.");
            this.checkBoxSettingsCheckForUpdatesAtLaunch.UseVisualStyleBackColor = true;
            this.checkBoxSettingsCheckForUpdatesAtLaunch.CheckedChanged += new System.EventHandler(this.checkBoxSettingsCheckForUpdatesAtLaunch_CheckedChanged);
            // 
            // buttonRestartWebsocket
            // 
            this.buttonRestartWebsocket.Location = new System.Drawing.Point(389, 262);
            this.buttonRestartWebsocket.Name = "buttonRestartWebsocket";
            this.buttonRestartWebsocket.Size = new System.Drawing.Size(155, 23);
            this.buttonRestartWebsocket.TabIndex = 22;
            this.buttonRestartWebsocket.Text = "Restart Websocket";
            this.buttonRestartWebsocket.UseVisualStyleBackColor = true;
            this.buttonRestartWebsocket.Click += new System.EventHandler(this.buttonRestartWebsocket_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Websocket Port:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericWebsocketPort
            // 
            this.numericWebsocketPort.Location = new System.Drawing.Point(479, 236);
            this.numericWebsocketPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericWebsocketPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.numericWebsocketPort.Name = "numericWebsocketPort";
            this.numericWebsocketPort.Size = new System.Drawing.Size(65, 20);
            this.numericWebsocketPort.TabIndex = 20;
            this.numericWebsocketPort.Value = new decimal(new int[] {
            9001,
            0,
            0,
            0});
            this.numericWebsocketPort.ValueChanged += new System.EventHandler(this.numericWebsocketPort_ValueChanged);
            // 
            // checkBoxStreamHideVotingEffectsIngame
            // 
            this.checkBoxStreamHideVotingEffectsIngame.AutoSize = true;
            this.checkBoxStreamHideVotingEffectsIngame.Checked = true;
            this.checkBoxStreamHideVotingEffectsIngame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStreamHideVotingEffectsIngame.Location = new System.Drawing.Point(9, 268);
            this.checkBoxStreamHideVotingEffectsIngame.Name = "checkBoxStreamHideVotingEffectsIngame";
            this.checkBoxStreamHideVotingEffectsIngame.Size = new System.Drawing.Size(155, 17);
            this.checkBoxStreamHideVotingEffectsIngame.TabIndex = 10;
            this.checkBoxStreamHideVotingEffectsIngame.Text = "Hide Voting Effects Ingame";
            this.toolTipHandler.SetToolTip(this.checkBoxStreamHideVotingEffectsIngame, "Some effects play a sound clip when\r\nthey get activated. Check this to have\r\nthem" +
        " play.");
            this.checkBoxStreamHideVotingEffectsIngame.UseVisualStyleBackColor = true;
            this.checkBoxStreamHideVotingEffectsIngame.CheckedChanged += new System.EventHandler(this.checkBoxStreamHideVotingEffectsIngame_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Seed:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Location = new System.Drawing.Point(47, 6);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(497, 20);
            this.textBoxSeed.TabIndex = 1;
            this.textBoxSeed.TextChanged += new System.EventHandler(this.TextBoxSeed_TextChanged);
            // 
            // tabExperimental
            // 
            this.tabExperimental.BackColor = System.Drawing.Color.Transparent;
            this.tabExperimental.Controls.Add(this.buttonExperimentalClearActiveEffects);
            this.tabExperimental.Controls.Add(this.buttonExperimentalRunEffect);
            this.tabExperimental.Controls.Add(this.textBoxExperimentalEffectName);
            this.tabExperimental.Controls.Add(this.checkBoxExperimental_RunEffectOnAutoStart);
            this.tabExperimental.Location = new System.Drawing.Point(4, 22);
            this.tabExperimental.Name = "tabExperimental";
            this.tabExperimental.Padding = new System.Windows.Forms.Padding(3);
            this.tabExperimental.Size = new System.Drawing.Size(552, 293);
            this.tabExperimental.TabIndex = 7;
            this.tabExperimental.Text = "Experimental";
            // 
            // buttonExperimentalRunEffect
            // 
            this.buttonExperimentalRunEffect.Location = new System.Drawing.Point(469, 263);
            this.buttonExperimentalRunEffect.Name = "buttonExperimentalRunEffect";
            this.buttonExperimentalRunEffect.Size = new System.Drawing.Size(75, 22);
            this.buttonExperimentalRunEffect.TabIndex = 15;
            this.buttonExperimentalRunEffect.Text = "Run";
            this.buttonExperimentalRunEffect.UseVisualStyleBackColor = true;
            this.buttonExperimentalRunEffect.Click += new System.EventHandler(this.ButtonExperimentalRunEffect_Click);
            // 
            // textBoxExperimentalEffectName
            // 
            this.textBoxExperimentalEffectName.Location = new System.Drawing.Point(8, 264);
            this.textBoxExperimentalEffectName.Name = "textBoxExperimentalEffectName";
            this.textBoxExperimentalEffectName.Size = new System.Drawing.Size(455, 20);
            this.textBoxExperimentalEffectName.TabIndex = 14;
            this.textBoxExperimentalEffectName.TextChanged += new System.EventHandler(this.TextBoxExperimentalEffectName_TextChanged);
            // 
            // checkBoxExperimental_RunEffectOnAutoStart
            // 
            this.checkBoxExperimental_RunEffectOnAutoStart.AutoSize = true;
            this.checkBoxExperimental_RunEffectOnAutoStart.Location = new System.Drawing.Point(6, 6);
            this.checkBoxExperimental_RunEffectOnAutoStart.Name = "checkBoxExperimental_RunEffectOnAutoStart";
            this.checkBoxExperimental_RunEffectOnAutoStart.Size = new System.Drawing.Size(157, 17);
            this.checkBoxExperimental_RunEffectOnAutoStart.TabIndex = 12;
            this.checkBoxExperimental_RunEffectOnAutoStart.Text = "Enable Effect On Auto-Start";
            this.toolTipHandler.SetToolTip(this.checkBoxExperimental_RunEffectOnAutoStart, "When auto-start kicks in\r\nit will enable an effect immediately\r\ninstead of only s" +
        "tarting the\r\ntimer.\r\nDoesn\'t work for Twitch mode.");
            this.checkBoxExperimental_RunEffectOnAutoStart.UseVisualStyleBackColor = true;
            this.checkBoxExperimental_RunEffectOnAutoStart.Click += new System.EventHandler(this.CheckBoxExperimental_EnableEffectOnAutoStart_CheckedChanged);
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(402, 16);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(73, 17);
            this.checkBoxAutoStart.TabIndex = 8;
            this.checkBoxAutoStart.Text = "Auto-Start";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.CheckBoxAutoStart_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPresetToolStripMenuItem,
            this.savePresetToolStripMenuItem,
            this.experimentalToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadPresetToolStripMenuItem
            // 
            this.loadPresetToolStripMenuItem.Name = "loadPresetToolStripMenuItem";
            this.loadPresetToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.loadPresetToolStripMenuItem.Text = "Load Preset";
            this.loadPresetToolStripMenuItem.Click += new System.EventHandler(this.LoadPresetToolStripMenuItem_Click);
            // 
            // savePresetToolStripMenuItem
            // 
            this.savePresetToolStripMenuItem.Name = "savePresetToolStripMenuItem";
            this.savePresetToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.savePresetToolStripMenuItem.Text = "Save Preset";
            this.savePresetToolStripMenuItem.Click += new System.EventHandler(this.SavePresetToolStripMenuItem_Click);
            // 
            // experimentalToolStripMenuItem
            // 
            this.experimentalToolStripMenuItem.Name = "experimentalToolStripMenuItem";
            this.experimentalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.experimentalToolStripMenuItem.Text = "Experimental";
            this.experimentalToolStripMenuItem.Click += new System.EventHandler(this.ExperimentalToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viceCityToolStripMenuItem,
            this.sanAndreasToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // viceCityToolStripMenuItem
            // 
            this.viceCityToolStripMenuItem.Name = "viceCityToolStripMenuItem";
            this.viceCityToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.viceCityToolStripMenuItem.Text = "Vice City";
            this.viceCityToolStripMenuItem.Click += new System.EventHandler(this.ViceCityToolStripMenuItem_Click);
            // 
            // sanAndreasToolStripMenuItem
            // 
            this.sanAndreasToolStripMenuItem.Name = "sanAndreasToolStripMenuItem";
            this.sanAndreasToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sanAndreasToolStripMenuItem.Text = "San Andreas";
            this.sanAndreasToolStripMenuItem.Click += new System.EventHandler(this.SanAndreasToolStripMenuItem_Click);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 10;
            this.timerMain.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // buttonSwitchMode
            // 
            this.buttonSwitchMode.Location = new System.Drawing.Point(481, 12);
            this.buttonSwitchMode.Name = "buttonSwitchMode";
            this.buttonSwitchMode.Size = new System.Drawing.Size(73, 23);
            this.buttonSwitchMode.TabIndex = 7;
            this.buttonSwitchMode.Text = "Stream";
            this.buttonSwitchMode.UseVisualStyleBackColor = true;
            this.buttonSwitchMode.Click += new System.EventHandler(this.ButtonSwitchMode_Click);
            // 
            // buttonExperimentalClearActiveEffects
            // 
            this.buttonExperimentalClearActiveEffects.Location = new System.Drawing.Point(431, 236);
            this.buttonExperimentalClearActiveEffects.Name = "buttonExperimentalClearActiveEffects";
            this.buttonExperimentalClearActiveEffects.Size = new System.Drawing.Size(113, 22);
            this.buttonExperimentalClearActiveEffects.TabIndex = 16;
            this.buttonExperimentalClearActiveEffects.Text = "Clear Active Effects";
            this.buttonExperimentalClearActiveEffects.UseVisualStyleBackColor = true;
            this.buttonExperimentalClearActiveEffects.Click += new System.EventHandler(this.buttonExperimentalClearActiveEffects_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 360);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.buttonSwitchMode);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "GTA:SA Chaos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabs.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabStream.ResumeLayout(false);
            this.tabStream.PerformLayout();
            this.tabPolls.ResumeLayout(false);
            this.tabPolls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTwitchPollsChannelPointsCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTwitchPollsBitsCost)).EndInit();
            this.tabEffects.ResumeLayout(false);
            this.tabEffects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEffectCooldown)).EndInit();
            this.tabSync.ResumeLayout(false);
            this.tabSync.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWebsocketPort)).EndInit();
            this.tabExperimental.ResumeLayout(false);
            this.tabExperimental.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMainToggle;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabEffects;
        private System.Windows.Forms.TreeView enabledEffectsView;
        private System.Windows.Forms.ListBox listLastEffectsMain;
        private System.Windows.Forms.ComboBox comboBoxMainCooldown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabStream;
        private System.Windows.Forms.TextBox textBoxStreamAccessToken;
        private System.Windows.Forms.Button buttonConnectStream;
        private System.Windows.Forms.ListBox listLastEffectsStream;
        private System.Windows.Forms.ToolTip toolTipHandler;
        private System.Windows.Forms.ComboBox comboBoxVotingCooldown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxVotingTime;
        private System.Windows.Forms.ProgressBar progressBarStream;
        private System.Windows.Forms.Button buttonStreamToggle;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Button buttonSwitchMode;
        private System.Windows.Forms.Label labelStreamCurrentMode;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Button buttonResetMain;
        private System.Windows.Forms.CheckBox checkBoxShowLastEffectsMain;
        private System.Windows.Forms.CheckBox checkBoxShowLastEffectsStream;
        private System.Windows.Forms.CheckBox checkBoxStreamAllowOnlyEnabledEffects;
        private System.Windows.Forms.Button buttonResetStream;
        private System.Windows.Forms.CheckBox checkBoxStream3TimesCooldown;
        private System.Windows.Forms.Button buttonEffectsToggleAll;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viceCityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sanAndreasToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxStreamEnableMultipleEffects;
        private System.Windows.Forms.TabPage tabPolls;
        private System.Windows.Forms.Label labelTwitchPollsBitsCost;
        private System.Windows.Forms.NumericUpDown numericUpDownTwitchPollsBitsCost;
        private System.Windows.Forms.CheckBox checkBoxTwitchPollsPostMessages;
        private System.Windows.Forms.TabPage tabSync;
        private System.Windows.Forms.TextBox textBoxSyncUsername;
        private System.Windows.Forms.Label labelSyncUsername;
        private System.Windows.Forms.Label labelSyncChannel;
        private System.Windows.Forms.TextBox textBoxSyncChannel;
        private System.Windows.Forms.Label labelSyncServer;
        private System.Windows.Forms.TextBox textBoxSyncServer;
        private System.Windows.Forms.Button buttonSyncConnect;
        private System.Windows.Forms.Label labelSyncHost;
        private System.Windows.Forms.Button buttonSyncSend;
        private System.Windows.Forms.TextBox textBoxSyncChat;
        private System.Windows.Forms.ListBox listBoxSyncChat;
        private System.Windows.Forms.TabPage tabExperimental;
        private System.Windows.Forms.ToolStripMenuItem experimentalToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxExperimental_RunEffectOnAutoStart;
        private System.Windows.Forms.Button buttonExperimentalRunEffect;
        private System.Windows.Forms.TextBox textBoxExperimentalEffectName;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.CheckBox checkBoxStreamEnableRapidFire;
        private System.Windows.Forms.CheckBox checkBoxStreamCombineVotingMessages;
        private System.Windows.Forms.CheckBox checkBoxTwitchUsePolls;
        private System.Windows.Forms.CheckBox checkBoxStreamMajorityVotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTwitchPollsChannelPointsCost;
        private System.Windows.Forms.LinkLabel linkLabelTwitchGetAccessToken;
        private System.Windows.Forms.Label labelStreamAccessToken;
        private System.Windows.Forms.Label labelStreamClientID;
        private System.Windows.Forms.TextBox textBoxStreamClientID;
        private System.Windows.Forms.Label labelEffectCooldown;
        private System.Windows.Forms.NumericUpDown numericUpDownEffectCooldown;
        private System.Windows.Forms.CheckBox checkBoxStreamHideVotingEffectsIngame;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericWebsocketPort;
        private System.Windows.Forms.Button buttonRestartWebsocket;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxSettingsCheckForUpdatesAtLaunch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSettingsStreamMode;
        private System.Windows.Forms.Button buttonExperimentalClearActiveEffects;
    }
}

