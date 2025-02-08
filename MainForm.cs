using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Linq;

namespace GateSwitchWay
{
    public partial class MainForm : Form
    {
        private static bool isAutoStartOn = false;
        private static bool startHidden = false;
        private static bool isLoadingSettings = false;

        private NetworkHelper.NetworkInfo currentNetworkInfo;
        private NetworkHelper.NetworkInfo alternativeNetworkInfo;

        public MainForm()
        {
            InitializeComponent();
            isAutoStartOn = AppAutoStart.GetAutoStart();
            autoStartMenu.Checked = isAutoStartOn;

            startHidden = Settings.Default.StartHidden;
            startHiddenMenu.Checked = startHidden;

            isSwitchedOn = false;
            notifyIcon1.Icon = isSwitchedOn ? Res.gw64_yg_TEA_icon : Res.gw64_g_vzI_icon;
            this.Icon = isSwitchedOn ? Res.gw64_yg_TEA_icon : Res.gw64_g_vzI_icon;

            currentNetworkInfo = NetworkHelper.GetCurrentNetworkInfo(); // Call the method to update the network info on startup
            NetworkHelper.UpdateTaskbarNetworkInfo(currentNetworkInfo, notifyIcon1, isSwitchedOn); // Display the current network info
            NetworkHelper.PopulateNetworkInfoTextBoxes(currentNetworkInfo, textBoxCurrentGw4, textBoxCurrentGw6, textBoxCurrentDns4, textBoxCurrentDns6);
            isLoadingSettings = true;
            NetworkHelper.LoadAlterNativeSettings(textBoxGw4, textBoxGw6, textBoxDns4, textBoxDns6, checkBoxGw4, checkBoxGw6, checkBoxDns4, checkBoxDns6);
            isLoadingSettings = false;
            NetworkHelper.PopulateNetworkInfoTextBoxes(currentNetworkInfo, textBoxNativeGw4, textBoxNativeGw6, textBoxNativeDns4, textBoxNativeDns6);

            clickTimer.Interval = SystemInformation.DoubleClickTime - 1; // Just under the double-click speed
            clickTimer.Tick += (s, e) =>
            {
                clickTimer.Stop(); // Stop the timer

                // Perform the single-click action if not a double-click
                if (!isDoubleClick)
                {
                    ToggleSwitch(); // Switch mode with single-click
                }
                isDoubleClick = false; // Reset the flag
            };

            if (notifyIcon1.ContextMenuStrip is not null)
            {
                notifyIcon1.ContextMenuStrip.Opening += (sender, e) =>
                {
                    UpdateContextMenuTheme(notifyIcon1.ContextMenuStrip);
                    autoStartMenu.Checked = AppAutoStart.GetAutoStart();
                    mainToolStripMenuItem.Checked = this.Visible;
                };
            }

            // Register the MouseClick event
            this.notifyIcon1.MouseClick += new MouseEventHandler(notifyIcon1_MouseClick);

            // Hide main window if startHidden is true
            if (startHidden)
            {
                this.Hide();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Update AlterNative settings display
            AlterCheckBoxes_ReEnable();
            // Hide main window if startHidden is true
            if (startHidden)
            {
                this.Hide();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static bool firstTimeCloseClicked = true;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Check if the close reason is a user action (e.g., clicking the 'X' button)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Cancel the form's closure
                e.Cancel = true;

                // Hide the form
                this.Hide();

                // Optionally, show a notification or message indicating the application is still running
                if (firstTimeCloseClicked)
                {
                    notifyIcon1.ShowBalloonTip(600, "Attempt to close", $"{AppAutoStart.taskName} running in the background.\nDouble click system tray icon to show main window. Once click to toggle active mode.", ToolTipIcon.Info);
                    firstTimeCloseClicked = false;
                }
            }
            else
            {
                // Allow the form to close for other close reasons (e.g., Application.Exit())
                base.OnFormClosing(e);
            }
        }

        // add theme support to context menu
        public class DarkModeToolStripRenderer : ToolStripProfessionalRenderer
        {
            public DarkModeToolStripRenderer() : base(new DarkModeColorTable())
            {
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                // Background of the entire menu
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), e.AffectedBounds);
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    // Highlight color for selected items
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)), new Rectangle(Point.Empty, e.Item.Size));
                }
                else
                {
                    // Regular item background color
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(Point.Empty, e.Item.Size));
                }
            }

            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                // Override the space on the left of items (where check marks or images go)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), e.AffectedBounds);
            }

            // Add overrides for other elements as needed, like separators, arrows, etc.
        }
        public class DarkModeColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(70, 70, 70);
            public override Color MenuItemBorder => Color.FromArgb(70, 70, 70);
            public override Color MenuBorder => Color.FromArgb(40, 40, 40);
            public override Color MenuStripGradientBegin => Color.FromArgb(40, 40, 40);
            public override Color MenuStripGradientEnd => Color.FromArgb(40, 40, 40);
            public override Color SeparatorDark => Color.FromArgb(32, 100, 32); // Dark background
        }

        // Timer to handle single-click action delay
        private System.Windows.Forms.Timer clickTimer = new System.Windows.Forms.Timer();

        // Flag to distinguish between single and double clicks
        private bool isDoubleClick = false;

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Check if the double click was with the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                isDoubleClick = true; // It's a double-click
                clickTimer.Stop(); // Stop the timer to prevent the single-click action

                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    activateMainWindow();
                }
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the click was with the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                isDoubleClick = false; // Assume it's not a double-click
                clickTimer.Start(); // Start the delay timer
            }
        }

        private void activateMainWindow()
        {
            this.Show();
            // Ensure the window is not minimized, but keep maximized or other state
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate(); // Bring the form to the forefront
        }

        private static bool isSwitchedOn = false;
        private void ToggleSwitch()
        {
            // Implement the switch on/off logic here
            isSwitchedOn = !isSwitchedOn;

            // Update the icon based on the new state
            notifyIcon1.Icon = isSwitchedOn ? Res.gw64_yg_TEA_icon : Res.gw64_g_vzI_icon;
            this.Icon = isSwitchedOn ? Res.gw64_yg_TEA_icon : Res.gw64_g_vzI_icon;

            this.Text = isSwitchedOn ? "AlterNative GateWay" : "Native GateWay";

            // Update network info to be consistent with current mode
            NetworkHelper.UpdateTaskbarNetworkInfo(currentNetworkInfo, notifyIcon1, isSwitchedOn);
        }

        private static bool currentLightThemeEnabled = false;
        private bool IsLightThemeEnabled()
        {
            var key = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            var valueName = "AppsUseLightTheme";

            currentLightThemeEnabled = false;
            using (var regKey = Registry.CurrentUser.OpenSubKey(key))
            {
                if (regKey != null)
                {
                    var value = regKey.GetValue(valueName);
                    if (value != null)
                    {
                        currentLightThemeEnabled = Convert.ToInt32(value) != 0;
                    }
                }
            }
            return currentLightThemeEnabled; // Default to dark theme if unable to read the registry
        }
        private void UpdateContextMenuTheme(ContextMenuStrip contextMenu)
        {
            if (IsLightThemeEnabled())
            {
                contextMenu.BackColor = SystemColors.ControlLightLight; // Light background
                contextMenu.ForeColor = Color.Black; // Dark text
            }
            else
            {
                contextMenu.BackColor = Color.FromArgb(255, 32, 32, 32); // Dark background
                contextMenu.ForeColor = Color.LightGray; // Light text
            }

            // add dark mode custom renderer to display menu items properly
            contextMenu.Renderer = IsLightThemeEnabled() ? new ToolStripProfessionalRenderer() : new DarkModeToolStripRenderer();
        }

        private void autoStartMenu_Click(object sender, EventArgs e)
        {
            // Toggle the auto-start setting based on its current state
            bool currentState = AppAutoStart.GetAutoStart();
            bool success = AppAutoStart.SetAutoStart(!currentState);

            if (success)
            {
                // Update the check state of the menu item to reflect the new state
                autoStartMenu.Checked = !currentState;
            }
            else
            {
                MessageBox.Show("Failed to toggle auto-start setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    activateMainWindow();
                }
                else
                {
                    this.Hide();
                }
            }
            else
            {
                activateMainWindow();
            }
        }
        private void startHiddenMenu_Click(object sender, EventArgs e)
        {
            startHidden = !startHidden;
            startHiddenMenu.Checked = startHidden;
            Settings.Default.StartHidden = startHidden;
            Settings.Default.Save();
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                bool needSave = false;
                switch (checkBox.Name)
                {
                    case "checkBoxGw4":
                    case "checkBoxGw6":
                    case "checkBoxDns4":
                    case "checkBoxDns6":
                        {
                            AlterCheckBoxes_ReEnable();
                            needSave = true;
                            break;
                        }
                }
                if (!isLoadingSettings)
                {
                    if (needSave)
                    {
                        NetworkHelper.SaveAlterNativeSettings(textBoxGw4, textBoxGw6, textBoxDns4, textBoxDns6, checkBoxGw4, checkBoxGw6, checkBoxDns4, checkBoxDns6);
                    }
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
    }
}
