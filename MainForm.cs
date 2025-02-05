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

        public struct NetworkInfo
        {
            public string Gateway4;
            public string Gateway6;
            public string Dns4;
            public string Dns6;
        }

        private NetworkInfo currentNetworkInfo;
        private NetworkInfo alternativeNetworkInfo;

        public MainForm()
        {
            InitializeComponent();
            //contextMenuStrip1.Renderer = new DarkModeToolStripRenderer();
            isAutoStartOn = AppAutoStart.GetAutoStart();
            autoStartMenu.Checked = isAutoStartOn;

            startHidden = Settings.Default.StartHidden;
            startHiddenMenu.Checked = startHidden;

            isSwitchedOn = false;
            notifyIcon1.Icon = isSwitchedOn ? Res.gw64_yg_TEA_icon : Res.gw64_g_vzI_icon;
            this.Icon = isSwitchedOn ? Res.gw64_yg_TEA_icon : Res.gw64_g_vzI_icon;
            //notifyIcon1.Icon = AppAutoStart.GetAutoStart() ? Res.gw64_yg_TEA_icon : Res.gw64_1_Jnv_icon;
            UpdateNetworkInfo(); // Call the method to update the network info on startup
            DisplayNetworkInfo(currentNetworkInfo); // Display the current network info

            //
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
            // Hide main window if startHidden is true
            if (startHidden)
            {
                this.Hide();
            }
        }
        private void UpdateNetworkInfo()
        {
            currentNetworkInfo = new NetworkInfo
            {
                Gateway4 = "N/A",
                Gateway6 = "N/A",
                Dns4 = "N/A",
                Dns6 = "N/A"
            };

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    IPInterfaceProperties ipProps = ni.GetIPProperties();

                    // Get the gateway addresses
                    var gateway4 = ipProps.GatewayAddresses
                        .FirstOrDefault(g => g.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    var gateway6 = ipProps.GatewayAddresses
                        .FirstOrDefault(g => g.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6);
                    currentNetworkInfo.Gateway4 = gateway4?.Address.ToString() ?? "N/A";
                    currentNetworkInfo.Gateway6 = gateway6?.Address.ToString() ?? "N/A";

                    // Get the DNS addresses
                    var dnsAddress4 = ipProps.DnsAddresses
                        .FirstOrDefault(d => d.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    var dnsAddress6 = ipProps.DnsAddresses
                        .FirstOrDefault(d => d.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6);
                    currentNetworkInfo.Dns4 = dnsAddress4?.ToString() ?? "N/A";
                    currentNetworkInfo.Dns6 = dnsAddress6?.ToString() ?? "N/A";

                    break; // Use the first active network interface
                }
            }
        }

        private void DisplayNetworkInfo(NetworkInfo networkInfo)
        {
            notifyIcon1.Text = $"GW4: {networkInfo.Gateway4}\rGW6: {networkInfo.Gateway6}\rDNS4: {networkInfo.Dns4}\rDNS6: {networkInfo.Dns6}";
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

            this.Text = isSwitchedOn ? "Switched On" : "Switched Off";
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
            //currentDarkThemeEnabled = false;
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

            // add dark mode custom renderer to display menu items propely
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
    }
}
