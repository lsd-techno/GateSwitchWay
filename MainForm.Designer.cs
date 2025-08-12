namespace GateSwitchWay
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                autoRefreshTimer?.Dispose();
                clickTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            mainToolStripMenuItem = new ToolStripMenuItem();
            startHiddenMenu = new ToolStripMenuItem();
            autoStartMenu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            groupBoxNative = new GroupBox();
            checkBoxNativeGw4 = new CheckBox();
            textBoxNativeGw4 = new TextBox();
            checkBoxNativeGw6 = new CheckBox();
            textBoxNativeGw6 = new TextBox();
            checkBoxNativeDns4 = new CheckBox();
            textBoxNativeDns4 = new TextBox();
            checkBoxNativeDns6 = new CheckBox();
            textBoxNativeDns6 = new TextBox();
            buttonSaveNative = new Button();
            buttonLoadNative = new Button();
            groupBoxAlterNative = new GroupBox();
            checkBoxGw4 = new CheckBox();
            checkBoxGw6 = new CheckBox();
            checkBoxDns4 = new CheckBox();
            checkBoxDns6 = new CheckBox();
            textBoxGw4 = new TextBox();
            textBoxGw6 = new TextBox();
            textBoxDns4 = new TextBox();
            textBoxDns6 = new TextBox();
            groupBoxCurrent = new GroupBox();
            labelCurrentGw4 = new Label();
            textBoxCurrentGw4 = new TextBox();
            labelCurrentGw6 = new Label();
            textBoxCurrentGw6 = new TextBox();
            labelCurrentDns4 = new Label();
            textBoxCurrentDns4 = new TextBox();
            labelCurrentDns6 = new Label();
            textBoxCurrentDns6 = new TextBox();
            trackBarToggle = new TrackBar();
            autoAlterMenu = new ToolStripMenuItem();
            refreshIntervalMenu = new ToolStripMenuItem();
            checkBoxAutoRefresh = new CheckBox();
            labelRefreshInterval = new Label();
            numericUpDownRefreshInterval = new NumericUpDown();
            labelRefreshIntervalUnit = new Label();
            contextMenuStrip1.SuspendLayout();
            groupBoxNative.SuspendLayout();
            groupBoxAlterNative.SuspendLayout();
            groupBoxCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarToggle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRefreshInterval).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = SystemColors.ButtonShadow;
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem, startHiddenMenu, autoAlterMenu, refreshIntervalMenu, autoStartMenu, toolStripSeparator1, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 164);
            // 
            // mainToolStripMenuItem
            // 
            mainToolStripMenuItem.Checked = true;
            mainToolStripMenuItem.CheckState = CheckState.Checked;
            mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            mainToolStripMenuItem.Size = new Size(180, 22);
            mainToolStripMenuItem.Text = "Main";
            mainToolStripMenuItem.Click += mainToolStripMenuItem_Click;
            // 
            // startHiddenMenu
            // 
            startHiddenMenu.Checked = true;
            startHiddenMenu.CheckState = CheckState.Checked;
            startHiddenMenu.Name = "startHiddenMenu";
            startHiddenMenu.Size = new Size(180, 22);
            startHiddenMenu.Text = "StartHidden";
            startHiddenMenu.Click += startHiddenMenu_Click;
            // 
            // autoAlterMenu
            // 
            autoAlterMenu.Checked = true;
            autoAlterMenu.CheckState = CheckState.Checked;
            autoAlterMenu.Name = "autoAlterMenu";
            autoAlterMenu.Size = new Size(180, 22);
            autoAlterMenu.Text = "AutoAlter";
            autoAlterMenu.Click += autoAlterMenu_Click;
            // 
            // autoStartMenu
            // 
            autoStartMenu.Checked = true;
            autoStartMenu.CheckState = CheckState.Checked;
            autoStartMenu.Name = "autoStartMenu";
            autoStartMenu.Size = new Size(180, 22);
            autoStartMenu.Text = "AutoStart";
            autoStartMenu.Click += autoStartMenu_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "exit";
            exitToolStripMenuItem.TextImageRelation = TextImageRelation.TextBeforeImage;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // groupBoxNative
            // 
            groupBoxNative.Controls.Add(checkBoxNativeGw4);
            groupBoxNative.Controls.Add(textBoxNativeGw4);
            groupBoxNative.Controls.Add(checkBoxNativeGw6);
            groupBoxNative.Controls.Add(textBoxNativeGw6);
            groupBoxNative.Controls.Add(checkBoxNativeDns4);
            groupBoxNative.Controls.Add(textBoxNativeDns4);
            groupBoxNative.Controls.Add(checkBoxNativeDns6);
            groupBoxNative.Controls.Add(textBoxNativeDns6);
            groupBoxNative.Controls.Add(buttonSaveNative);
            groupBoxNative.Controls.Add(buttonLoadNative);
            groupBoxNative.Font = new Font("Segoe UI", 9F);
            groupBoxNative.Location = new Point(12, 12);
            groupBoxNative.Name = "groupBoxNative";
            groupBoxNative.Size = new Size(270, 180);
            groupBoxNative.TabIndex = 0;
            groupBoxNative.TabStop = false;
            groupBoxNative.Text = "Native";
            // 
            // checkBoxNativeGw4
            // 
            checkBoxNativeGw4.AutoSize = true;
            checkBoxNativeGw4.Location = new Point(6, 25);
            checkBoxNativeGw4.Name = "checkBoxNativeGw4";
            checkBoxNativeGw4.Size = new Size(50, 19);
            checkBoxNativeGw4.TabIndex = 11;
            checkBoxNativeGw4.Text = "GW4";
            checkBoxNativeGw4.UseVisualStyleBackColor = true;
            checkBoxNativeGw4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // textBoxNativeGw4
            // 
            textBoxNativeGw4.Enabled = false;
            textBoxNativeGw4.Location = new Point(72, 22);
            textBoxNativeGw4.Name = "textBoxNativeGw4";
            textBoxNativeGw4.Size = new Size(192, 23);
            textBoxNativeGw4.TabIndex = 0;
            // 
            // checkBoxNativeGw6
            // 
            checkBoxNativeGw6.AutoSize = true;
            checkBoxNativeGw6.Location = new Point(6, 55);
            checkBoxNativeGw6.Name = "checkBoxNativeGw6";
            checkBoxNativeGw6.Size = new Size(50, 19);
            checkBoxNativeGw6.TabIndex = 12;
            checkBoxNativeGw6.Text = "GW6";
            checkBoxNativeGw6.UseVisualStyleBackColor = true;
            checkBoxNativeGw6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // textBoxNativeGw6
            // 
            textBoxNativeGw6.Enabled = false;
            textBoxNativeGw6.Location = new Point(72, 52);
            textBoxNativeGw6.Name = "textBoxNativeGw6";
            textBoxNativeGw6.Size = new Size(192, 23);
            textBoxNativeGw6.TabIndex = 1;
            // 
            // checkBoxNativeDns4
            // 
            checkBoxNativeDns4.AutoSize = true;
            checkBoxNativeDns4.Location = new Point(6, 85);
            checkBoxNativeDns4.Name = "checkBoxNativeDns4";
            checkBoxNativeDns4.Size = new Size(57, 19);
            checkBoxNativeDns4.TabIndex = 13;
            checkBoxNativeDns4.Text = "DNS4";
            checkBoxNativeDns4.UseVisualStyleBackColor = true;
            checkBoxNativeDns4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // textBoxNativeDns4
            // 
            textBoxNativeDns4.Enabled = false;
            textBoxNativeDns4.Location = new Point(72, 82);
            textBoxNativeDns4.Name = "textBoxNativeDns4";
            textBoxNativeDns4.Size = new Size(192, 23);
            textBoxNativeDns4.TabIndex = 2;
            // 
            // checkBoxNativeDns6
            // 
            checkBoxNativeDns6.AutoSize = true;
            checkBoxNativeDns6.Location = new Point(6, 115);
            checkBoxNativeDns6.Name = "checkBoxNativeDns6";
            checkBoxNativeDns6.Size = new Size(57, 19);
            checkBoxNativeDns6.TabIndex = 14;
            checkBoxNativeDns6.Text = "DNS6";
            checkBoxNativeDns6.UseVisualStyleBackColor = true;
            checkBoxNativeDns6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // textBoxNativeDns6
            // 
            textBoxNativeDns6.Enabled = false;
            textBoxNativeDns6.Location = new Point(72, 112);
            textBoxNativeDns6.Name = "textBoxNativeDns6";
            textBoxNativeDns6.Size = new Size(192, 23);
            textBoxNativeDns6.TabIndex = 3;
            // 
            // buttonSaveNative
            // 
            buttonSaveNative.Location = new Point(72, 145);
            buttonSaveNative.Name = "buttonSaveNative";
            buttonSaveNative.Size = new Size(92, 23);
            buttonSaveNative.TabIndex = 4;
            buttonSaveNative.Text = "Save";
            buttonSaveNative.UseVisualStyleBackColor = true;
            buttonSaveNative.Click += buttonSaveNative_Click;
            // 
            // buttonLoadNative
            // 
            buttonLoadNative.Location = new Point(172, 145);
            buttonLoadNative.Name = "buttonLoadNative";
            buttonLoadNative.Size = new Size(92, 23);
            buttonLoadNative.TabIndex = 5;
            buttonLoadNative.Text = "Load Current";
            buttonLoadNative.UseVisualStyleBackColor = true;
            buttonLoadNative.Click += buttonLoadNative_Click;
            // 
            // groupBoxAlterNative
            // 
            groupBoxAlterNative.Controls.Add(checkBoxGw4);
            groupBoxAlterNative.Controls.Add(checkBoxGw6);
            groupBoxAlterNative.Controls.Add(checkBoxDns4);
            groupBoxAlterNative.Controls.Add(checkBoxDns6);
            groupBoxAlterNative.Controls.Add(textBoxGw4);
            groupBoxAlterNative.Controls.Add(textBoxGw6);
            groupBoxAlterNative.Controls.Add(textBoxDns4);
            groupBoxAlterNative.Controls.Add(textBoxDns6);
            groupBoxAlterNative.Location = new Point(351, 12);
            groupBoxAlterNative.Name = "groupBoxAlterNative";
            groupBoxAlterNative.Size = new Size(270, 150);
            groupBoxAlterNative.TabIndex = 1;
            groupBoxAlterNative.TabStop = false;
            groupBoxAlterNative.Text = "AlterNative";
            // 
            // checkBoxGw4
            // 
            checkBoxGw4.Location = new Point(6, 22);
            checkBoxGw4.Name = "checkBoxGw4";
            checkBoxGw4.Size = new Size(60, 24);
            checkBoxGw4.TabIndex = 0;
            checkBoxGw4.Text = "GW4";
            checkBoxGw4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxGw6
            // 
            checkBoxGw6.Location = new Point(6, 52);
            checkBoxGw6.Name = "checkBoxGw6";
            checkBoxGw6.Size = new Size(60, 24);
            checkBoxGw6.TabIndex = 1;
            checkBoxGw6.Text = "GW6";
            checkBoxGw6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxDns4
            // 
            checkBoxDns4.Location = new Point(6, 82);
            checkBoxDns4.Name = "checkBoxDns4";
            checkBoxDns4.Size = new Size(60, 24);
            checkBoxDns4.TabIndex = 2;
            checkBoxDns4.Text = "DNS4";
            checkBoxDns4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxDns6
            // 
            checkBoxDns6.Location = new Point(6, 112);
            checkBoxDns6.Name = "checkBoxDns6";
            checkBoxDns6.Size = new Size(60, 24);
            checkBoxDns6.TabIndex = 3;
            checkBoxDns6.Text = "DNS6";
            checkBoxDns6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // textBoxGw4
            // 
            textBoxGw4.Enabled = false;
            textBoxGw4.Location = new Point(72, 22);
            textBoxGw4.Name = "textBoxGw4";
            textBoxGw4.Size = new Size(192, 23);
            textBoxGw4.TabIndex = 4;
            // 
            // textBoxGw6
            // 
            textBoxGw6.Enabled = false;
            textBoxGw6.Location = new Point(72, 52);
            textBoxGw6.Name = "textBoxGw6";
            textBoxGw6.Size = new Size(192, 23);
            textBoxGw6.TabIndex = 5;
            // 
            // textBoxDns4
            // 
            textBoxDns4.Enabled = false;
            textBoxDns4.Location = new Point(72, 82);
            textBoxDns4.Name = "textBoxDns4";
            textBoxDns4.Size = new Size(192, 23);
            textBoxDns4.TabIndex = 6;
            // 
            // textBoxDns6
            // 
            textBoxDns6.Enabled = false;
            textBoxDns6.Location = new Point(72, 112);
            textBoxDns6.Name = "textBoxDns6";
            textBoxDns6.Size = new Size(192, 23);
            textBoxDns6.TabIndex = 7;
            // 
            // groupBoxCurrent
            // 
            groupBoxCurrent.Controls.Add(labelCurrentGw4);
            groupBoxCurrent.Controls.Add(textBoxCurrentGw4);
            groupBoxCurrent.Controls.Add(labelCurrentGw6);
            groupBoxCurrent.Controls.Add(textBoxCurrentGw6);
            groupBoxCurrent.Controls.Add(labelCurrentDns4);
            groupBoxCurrent.Controls.Add(textBoxCurrentDns4);
            groupBoxCurrent.Controls.Add(labelCurrentDns6);
            groupBoxCurrent.Controls.Add(textBoxCurrentDns6);
            groupBoxCurrent.Controls.Add(checkBoxAutoRefresh);
            groupBoxCurrent.Controls.Add(labelRefreshInterval);
            groupBoxCurrent.Controls.Add(numericUpDownRefreshInterval);
            groupBoxCurrent.Controls.Add(labelRefreshIntervalUnit);
            groupBoxCurrent.Location = new Point(12, 205);
            groupBoxCurrent.Name = "groupBoxCurrent";
            groupBoxCurrent.Size = new Size(270, 180);
            groupBoxCurrent.TabIndex = 2;
            groupBoxCurrent.TabStop = false;
            groupBoxCurrent.Text = "Current";
            // 
            // labelCurrentGw4
            // 
            labelCurrentGw4.Location = new Point(6, 22);
            labelCurrentGw4.Name = "labelCurrentGw4";
            labelCurrentGw4.Size = new Size(60, 24);
            labelCurrentGw4.TabIndex = 0;
            labelCurrentGw4.Text = "GW4:";
            // 
            // textBoxCurrentGw4
            // 
            textBoxCurrentGw4.Location = new Point(72, 22);
            textBoxCurrentGw4.Name = "textBoxCurrentGw4";
            textBoxCurrentGw4.ReadOnly = true;
            textBoxCurrentGw4.Size = new Size(192, 23);
            textBoxCurrentGw4.TabIndex = 0;
            // 
            // labelCurrentGw6
            // 
            labelCurrentGw6.Location = new Point(6, 52);
            labelCurrentGw6.Name = "labelCurrentGw6";
            labelCurrentGw6.Size = new Size(60, 24);
            labelCurrentGw6.TabIndex = 2;
            labelCurrentGw6.Text = "GW6:";
            // 
            // textBoxCurrentGw6
            // 
            textBoxCurrentGw6.Location = new Point(72, 52);
            textBoxCurrentGw6.Name = "textBoxCurrentGw6";
            textBoxCurrentGw6.ReadOnly = true;
            textBoxCurrentGw6.Size = new Size(192, 23);
            textBoxCurrentGw6.TabIndex = 1;
            // 
            // labelCurrentDns4
            // 
            labelCurrentDns4.Location = new Point(6, 82);
            labelCurrentDns4.Name = "labelCurrentDns4";
            labelCurrentDns4.Size = new Size(60, 24);
            labelCurrentDns4.TabIndex = 4;
            labelCurrentDns4.Text = "DNS4:";
            // 
            // textBoxCurrentDns4
            // 
            textBoxCurrentDns4.Location = new Point(72, 82);
            textBoxCurrentDns4.Name = "textBoxCurrentDns4";
            textBoxCurrentDns4.ReadOnly = true;
            textBoxCurrentDns4.Size = new Size(192, 23);
            textBoxCurrentDns4.TabIndex = 2;
            // 
            // labelCurrentDns6
            // 
            labelCurrentDns6.Location = new Point(6, 112);
            labelCurrentDns6.Name = "labelCurrentDns6";
            labelCurrentDns6.Size = new Size(60, 24);
            labelCurrentDns6.TabIndex = 6;
            labelCurrentDns6.Text = "DNS6:";
            // 
            // textBoxCurrentDns6
            // 
            textBoxCurrentDns6.Location = new Point(72, 112);
            textBoxCurrentDns6.Name = "textBoxCurrentDns6";
            textBoxCurrentDns6.ReadOnly = true;
            textBoxCurrentDns6.Size = new Size(192, 23);
            textBoxCurrentDns6.TabIndex = 3;
            // 
            // trackBarToggle
            // 
            trackBarToggle.Location = new Point(289, 64);
            trackBarToggle.Maximum = 1;
            trackBarToggle.Name = "trackBarToggle";
            trackBarToggle.Size = new Size(56, 45);
            trackBarToggle.TabIndex = 1;
            trackBarToggle.TickStyle = TickStyle.None;
            trackBarToggle.ValueChanged += TrackBarToggle_ValueChanged;
            // 
            // refreshIntervalMenu
            // 
            refreshIntervalMenu.Name = "refreshIntervalMenu";
            refreshIntervalMenu.Size = new Size(180, 22);
            refreshIntervalMenu.Text = "Auto Refresh";
            refreshIntervalMenu.Click += refreshIntervalMenu_Click;
            // 
            // checkBoxAutoRefresh
            // 
            checkBoxAutoRefresh.AutoSize = true;
            checkBoxAutoRefresh.Location = new Point(210, 142);
            checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            checkBoxAutoRefresh.Size = new Size(54, 19);
            checkBoxAutoRefresh.TabIndex = 7;
            checkBoxAutoRefresh.Text = "Auto";
            checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            checkBoxAutoRefresh.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // labelRefreshInterval
            // 
            labelRefreshInterval.AutoSize = true;
            labelRefreshInterval.Location = new Point(6, 142);
            labelRefreshInterval.Name = "labelRefreshInterval";
            labelRefreshInterval.Size = new Size(55, 15);
            labelRefreshInterval.TabIndex = 8;
            labelRefreshInterval.Text = "Interval:";
            // 
            // numericUpDownRefreshInterval
            // 
            numericUpDownRefreshInterval.Location = new Point(72, 140);
            numericUpDownRefreshInterval.Name = "numericUpDownRefreshInterval";
            numericUpDownRefreshInterval.Size = new Size(92, 23);
            numericUpDownRefreshInterval.TabIndex = 9;
            numericUpDownRefreshInterval.ValueChanged += NumericUpDownRefreshInterval_ValueChanged;
            // 
            // labelRefreshIntervalUnit
            // 
            labelRefreshIntervalUnit.AutoSize = true;
            labelRefreshIntervalUnit.Location = new Point(170, 142);
            labelRefreshIntervalUnit.Name = "labelRefreshIntervalUnit";
            labelRefreshIntervalUnit.Size = new Size(36, 15);
            labelRefreshIntervalUnit.TabIndex = 10;
            labelRefreshIntervalUnit.Text = "secs";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxNative);
            Controls.Add(trackBarToggle);
            Controls.Add(groupBoxAlterNative);
            Controls.Add(groupBoxCurrent);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "GateSwitchWay";
            contextMenuStrip1.ResumeLayout(false);
            groupBoxNative.ResumeLayout(false);
            groupBoxNative.PerformLayout();
            groupBoxAlterNative.ResumeLayout(false);
            groupBoxAlterNative.PerformLayout();
            groupBoxCurrent.ResumeLayout(false);
            groupBoxCurrent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarToggle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRefreshInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem autoStartMenu;
        private ToolStripMenuItem startHiddenMenu;
        private ToolStripMenuItem autoAlterMenu;
        private ToolStripMenuItem refreshIntervalMenu;
        private GroupBox groupBoxNative;
        private GroupBox groupBoxAlterNative;
        private GroupBox groupBoxCurrent;
        // AlterNative settings
        private CheckBox checkBoxGw4;
        private CheckBox checkBoxGw6;
        private CheckBox checkBoxDns4;
        private CheckBox checkBoxDns6;
        private TextBox textBoxGw4;
        private TextBox textBoxGw6;
        private TextBox textBoxDns4;
        private TextBox textBoxDns6;
        // Native settings checkboxes
        private CheckBox checkBoxNativeGw4;
        private CheckBox checkBoxNativeGw6;
        private CheckBox checkBoxNativeDns4;
        private CheckBox checkBoxNativeDns6;
        private TextBox textBoxNativeGw4;
        private TextBox textBoxNativeGw6;
        private TextBox textBoxNativeDns4;
        private TextBox textBoxNativeDns6;
        private TextBox textBoxCurrentGw4;
        private TextBox textBoxCurrentGw6;
        private TextBox textBoxCurrentDns4;
        private TextBox textBoxCurrentDns6;
        private Button buttonSaveNative;
        private Button buttonLoadNative;

        // Toggle bar
        private TrackBar trackBarToggle;

        // Native and Current field names - Remove old Native labels since we're using checkboxes now
        private Label labelCurrentGw4;
        private Label labelCurrentGw6;
        private Label labelCurrentDns4;
        private Label labelCurrentDns6;
        private CheckBox checkBoxAutoRefresh;
        private Label labelRefreshInterval;
        private NumericUpDown numericUpDownRefreshInterval;
        private Label labelRefreshIntervalUnit;
    }
}
