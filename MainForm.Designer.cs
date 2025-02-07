namespace GateSwitchWay
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBoxNative;
        private GroupBox groupBoxAlterNative;
        private GroupBox groupBoxCurrent;
        private CheckBox checkBoxGw4;
        private CheckBox checkBoxGw6;
        private CheckBox checkBoxDns4;
        private CheckBox checkBoxDns6;
        private TextBox textBoxGw4;
        private TextBox textBoxGw6;
        private TextBox textBoxDns4;
        private TextBox textBoxDns6;
        private TextBox textBoxNativeGw4;
        private TextBox textBoxNativeGw6;
        private TextBox textBoxNativeDns4;
        private TextBox textBoxNativeDns6;
        private TextBox textBoxCurrentGw4;
        private TextBox textBoxCurrentGw6;
        private TextBox textBoxCurrentDns4;
        private TextBox textBoxCurrentDns6;
        /// <summary>
        ///  Clean up any resources being used.
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
            textBoxNativeGw4 = new TextBox();
            textBoxNativeGw6 = new TextBox();
            textBoxNativeDns4 = new TextBox();
            textBoxNativeDns6 = new TextBox();
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
            textBoxCurrentGw4 = new TextBox();
            textBoxCurrentGw6 = new TextBox();
            textBoxCurrentDns4 = new TextBox();
            textBoxCurrentDns6 = new TextBox();
            contextMenuStrip1.SuspendLayout();
            groupBoxNative.SuspendLayout();
            groupBoxAlterNative.SuspendLayout();
            groupBoxCurrent.SuspendLayout();
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
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem, startHiddenMenu, autoStartMenu, toolStripSeparator1, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(138, 98);
            // 
            // mainToolStripMenuItem
            // 
            mainToolStripMenuItem.Checked = true;
            mainToolStripMenuItem.CheckState = CheckState.Checked;
            mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            mainToolStripMenuItem.Size = new Size(137, 22);
            mainToolStripMenuItem.Text = "Main";
            mainToolStripMenuItem.Click += mainToolStripMenuItem_Click;
            // 
            // startHiddenMenu
            // 
            startHiddenMenu.Checked = true;
            startHiddenMenu.CheckState = CheckState.Checked;
            startHiddenMenu.Name = "startHiddenMenu";
            startHiddenMenu.Size = new Size(137, 22);
            startHiddenMenu.Text = "StartHidden";
            startHiddenMenu.Click += startHiddenMenu_Click;
            // 
            // autoStartMenu
            // 
            autoStartMenu.Checked = true;
            autoStartMenu.CheckState = CheckState.Checked;
            autoStartMenu.Name = "autoStartMenu";
            autoStartMenu.Size = new Size(137, 22);
            autoStartMenu.Text = "AutoStart";
            autoStartMenu.Click += autoStartMenu_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(134, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(137, 22);
            exitToolStripMenuItem.Text = "exit";
            exitToolStripMenuItem.TextImageRelation = TextImageRelation.TextBeforeImage;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // groupBoxNative
            // 
            groupBoxNative.Controls.Add(textBoxNativeGw4);
            groupBoxNative.Controls.Add(textBoxNativeGw6);
            groupBoxNative.Controls.Add(textBoxNativeDns4);
            groupBoxNative.Controls.Add(textBoxNativeDns6);
            groupBoxNative.Location = new Point(12, 12);
            groupBoxNative.Name = "groupBoxNative";
            groupBoxNative.Size = new Size(200, 150);
            groupBoxNative.TabIndex = 0;
            groupBoxNative.TabStop = false;
            groupBoxNative.Text = "Native";
            // 
            // textBoxNativeGw4
            // 
            textBoxNativeGw4.Location = new Point(6, 22);
            textBoxNativeGw4.Name = "textBoxNativeGw4";
            textBoxNativeGw4.ReadOnly = true;
            textBoxNativeGw4.Size = new Size(188, 23);
            textBoxNativeGw4.TabIndex = 0;
            // 
            // textBoxNativeGw6
            // 
            textBoxNativeGw6.Location = new Point(6, 52);
            textBoxNativeGw6.Name = "textBoxNativeGw6";
            textBoxNativeGw6.ReadOnly = true;
            textBoxNativeGw6.Size = new Size(188, 23);
            textBoxNativeGw6.TabIndex = 1;
            // 
            // textBoxNativeDns4
            // 
            textBoxNativeDns4.Location = new Point(6, 82);
            textBoxNativeDns4.Name = "textBoxNativeDns4";
            textBoxNativeDns4.ReadOnly = true;
            textBoxNativeDns4.Size = new Size(188, 23);
            textBoxNativeDns4.TabIndex = 2;
            // 
            // textBoxNativeDns6
            // 
            textBoxNativeDns6.Location = new Point(6, 112);
            textBoxNativeDns6.Name = "textBoxNativeDns6";
            textBoxNativeDns6.ReadOnly = true;
            textBoxNativeDns6.Size = new Size(188, 23);
            textBoxNativeDns6.TabIndex = 3;
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
            groupBoxAlterNative.Location = new Point(277, 12);
            groupBoxAlterNative.Name = "groupBoxAlterNative";
            groupBoxAlterNative.Size = new Size(200, 150);
            groupBoxAlterNative.TabIndex = 1;
            groupBoxAlterNative.TabStop = false;
            groupBoxAlterNative.Text = "AlterNative";
            // 
            // checkBoxGw4
            // 
            checkBoxGw4.Location = new Point(6, 22);
            checkBoxGw4.Name = "checkBoxGw4";
            checkBoxGw4.Size = new Size(80, 24);
            checkBoxGw4.TabIndex = 0;
            checkBoxGw4.Text = "GW4";
            checkBoxGw4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxGw6
            // 
            checkBoxGw6.Location = new Point(6, 52);
            checkBoxGw6.Name = "checkBoxGw6";
            checkBoxGw6.Size = new Size(80, 24);
            checkBoxGw6.TabIndex = 1;
            checkBoxGw6.Text = "GW6";
            checkBoxGw6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxDns4
            // 
            checkBoxDns4.Location = new Point(6, 82);
            checkBoxDns4.Name = "checkBoxDns4";
            checkBoxDns4.Size = new Size(80, 24);
            checkBoxDns4.TabIndex = 2;
            checkBoxDns4.Text = "DNS4";
            checkBoxDns4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxDns6
            // 
            checkBoxDns6.Location = new Point(6, 112);
            checkBoxDns6.Name = "checkBoxDns6";
            checkBoxDns6.Size = new Size(80, 24);
            checkBoxDns6.TabIndex = 3;
            checkBoxDns6.Text = "DNS6";
            checkBoxDns6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // textBoxGw4
            // 
            textBoxGw4.Enabled = false;
            textBoxGw4.Location = new Point(92, 22);
            textBoxGw4.Name = "textBoxGw4";
            textBoxGw4.Size = new Size(100, 23);
            textBoxGw4.TabIndex = 4;
            // 
            // textBoxGw6
            // 
            textBoxGw6.Enabled = false;
            textBoxGw6.Location = new Point(92, 52);
            textBoxGw6.Name = "textBoxGw6";
            textBoxGw6.Size = new Size(100, 23);
            textBoxGw6.TabIndex = 5;
            // 
            // textBoxDns4
            // 
            textBoxDns4.Enabled = false;
            textBoxDns4.Location = new Point(92, 82);
            textBoxDns4.Name = "textBoxDns4";
            textBoxDns4.Size = new Size(100, 23);
            textBoxDns4.TabIndex = 6;
            // 
            // textBoxDns6
            // 
            textBoxDns6.Enabled = false;
            textBoxDns6.Location = new Point(92, 112);
            textBoxDns6.Name = "textBoxDns6";
            textBoxDns6.Size = new Size(100, 23);
            textBoxDns6.TabIndex = 7;
            // 
            // groupBoxCurrent
            // 
            groupBoxCurrent.Controls.Add(textBoxCurrentGw4);
            groupBoxCurrent.Controls.Add(textBoxCurrentGw6);
            groupBoxCurrent.Controls.Add(textBoxCurrentDns4);
            groupBoxCurrent.Controls.Add(textBoxCurrentDns6);
            groupBoxCurrent.Location = new Point(12, 181);
            groupBoxCurrent.Name = "groupBoxCurrent";
            groupBoxCurrent.Size = new Size(200, 150);
            groupBoxCurrent.TabIndex = 2;
            groupBoxCurrent.TabStop = false;
            groupBoxCurrent.Text = "Current";
            // 
            // textBoxCurrentGw4
            // 
            textBoxCurrentGw4.Location = new Point(6, 22);
            textBoxCurrentGw4.Name = "textBoxCurrentGw4";
            textBoxCurrentGw4.ReadOnly = true;
            textBoxCurrentGw4.Size = new Size(188, 23);
            textBoxCurrentGw4.TabIndex = 0;
            // 
            // textBoxCurrentGw6
            // 
            textBoxCurrentGw6.Location = new Point(6, 52);
            textBoxCurrentGw6.Name = "textBoxCurrentGw6";
            textBoxCurrentGw6.ReadOnly = true;
            textBoxCurrentGw6.Size = new Size(188, 23);
            textBoxCurrentGw6.TabIndex = 1;
            // 
            // textBoxCurrentDns4
            // 
            textBoxCurrentDns4.Location = new Point(6, 82);
            textBoxCurrentDns4.Name = "textBoxCurrentDns4";
            textBoxCurrentDns4.ReadOnly = true;
            textBoxCurrentDns4.Size = new Size(188, 23);
            textBoxCurrentDns4.TabIndex = 2;
            // 
            // textBoxCurrentDns6
            // 
            textBoxCurrentDns6.Location = new Point(6, 112);
            textBoxCurrentDns6.Name = "textBoxCurrentDns6";
            textBoxCurrentDns6.ReadOnly = true;
            textBoxCurrentDns6.Size = new Size(188, 23);
            textBoxCurrentDns6.TabIndex = 3;
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
            Controls.Add(groupBoxAlterNative);
            Controls.Add(groupBoxCurrent);
            FormBorderStyle = FormBorderStyle.Fixed3D;
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
            ResumeLayout(false);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                switch (checkBox.Name)
                {
                    case "checkBoxGw4":
                        textBoxGw4.Enabled = checkBox.Checked;
                        break;
                    case "checkBoxGw6":
                        textBoxGw6.Enabled = checkBox.Checked;
                        break;
                    case "checkBoxDns4":
                        textBoxDns4.Enabled = checkBox.Checked;
                        break;
                    case "checkBoxDns6":
                        textBoxDns6.Enabled = checkBox.Checked;
                        break;
                }
            }
        }
        private void AlterCheckBoxes_ReEnable()
        {
            textBoxGw4.Enabled = checkBoxGw4.Checked;
            textBoxGw6.Enabled = checkBoxGw6.Checked;
            textBoxDns4.Enabled = checkBoxDns4.Checked;
            textBoxDns6.Enabled = checkBoxDns6.Checked;
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem autoStartMenu;
        private ToolStripMenuItem startHiddenMenu;
    }
}
