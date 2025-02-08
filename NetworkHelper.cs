using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using static GateSwitchWay.NetworkHelper;

namespace GateSwitchWay
{
    public static class NetworkHelper
    {
        public struct NetworkInfo
        {
            public bool Gateway4_enable;
            public string Gateway4;
            public bool Gateway6_enable;
            public string Gateway6;
            public bool Dns4_enable;
            public string Dns4;
            public bool Dns6_enable;
            public string Dns6;
        }

        public static NetworkInfo GetCurrentNetworkInfo()
        {
            NetworkInfo currentNetworkInfo = new NetworkInfo
            {
                Gateway4 = "N/A",
                Gateway6 = "N/A",
                Dns4 = "N/A",
                Dns6 = "N/A",
                Gateway4_enable = false,
                Gateway6_enable = false,
                Dns4_enable = false,
                Dns6_enable = false
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
                    currentNetworkInfo.Gateway4_enable = gateway4 != null;
                    currentNetworkInfo.Gateway6_enable = gateway6 != null;

                    // Get the DNS addresses
                    var dnsAddress4 = ipProps.DnsAddresses
                        .FirstOrDefault(d => d.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    var dnsAddress6 = ipProps.DnsAddresses
                        .FirstOrDefault(d => d.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6);
                    currentNetworkInfo.Dns4 = dnsAddress4?.ToString() ?? "N/A";
                    currentNetworkInfo.Dns6 = dnsAddress6?.ToString() ?? "N/A";
                    currentNetworkInfo.Dns4_enable = dnsAddress4 != null;
                    currentNetworkInfo.Dns6_enable = dnsAddress6 != null;

                    break; // Use the first active network interface
                }
            }

            return currentNetworkInfo;
        }

        public static void UpdateTaskbarNetworkInfo(NetworkInfo networkInfo, NotifyIcon notifyIcon, bool isSwitchedOn)
        {
            notifyIcon.Text = $"{(isSwitchedOn ? "AlterNative GW" : "Native GW")}\rGW4: {networkInfo.Gateway4}\rGW6: {networkInfo.Gateway6}\rDNS4: {networkInfo.Dns4}\rDNS6: {networkInfo.Dns6}";
        }

        public static void PopulateNetworkInfoTextBoxes(NetworkInfo networkInfo, TextBox textBoxGw4, TextBox textBoxGw6, TextBox textBoxDns4, TextBox textBoxDns6)
        {
            textBoxGw4.Text = networkInfo.Gateway4;
            textBoxGw6.Text = networkInfo.Gateway6;
            textBoxDns4.Text = networkInfo.Dns4;
            textBoxDns6.Text = networkInfo.Dns6;
        }

        public static void LoadAlterNativeSettings(TextBox textBoxGw4, TextBox textBoxGw6, TextBox textBoxDns4, TextBox textBoxDns6, CheckBox checkBoxGw4, CheckBox checkBoxGw6, CheckBox checkBoxDns4, CheckBox checkBoxDns6)
        {
            textBoxGw4.Text = Settings.Default.AlterNativeGw4;
            textBoxGw6.Text = Settings.Default.AlterNativeGw6;
            textBoxDns4.Text = Settings.Default.AlterNativeDns4;
            textBoxDns6.Text = Settings.Default.AlterNativeDns6;

            checkBoxGw4.Checked = Settings.Default.AlterNativeGw4Enabled;
            checkBoxGw6.Checked = Settings.Default.AlterNativeGw6Enabled;
            checkBoxDns4.Checked = Settings.Default.AlterNativeDns4Enabled;
            checkBoxDns6.Checked = Settings.Default.AlterNativeDns6Enabled;
        }

        public static void SaveAlterNativeSettings(TextBox textBoxGw4, TextBox textBoxGw6, TextBox textBoxDns4, TextBox textBoxDns6, CheckBox checkBoxGw4, CheckBox checkBoxGw6, CheckBox checkBoxDns4, CheckBox checkBoxDns6)
        {
            Settings.Default.AlterNativeGw4 = textBoxGw4.Text;
            Settings.Default.AlterNativeGw6 = textBoxGw6.Text;
            Settings.Default.AlterNativeDns4 = textBoxDns4.Text;
            Settings.Default.AlterNativeDns6 = textBoxDns6.Text;

            Settings.Default.AlterNativeGw4Enabled = checkBoxGw4.Checked;
            Settings.Default.AlterNativeGw6Enabled = checkBoxGw6.Checked;
            Settings.Default.AlterNativeDns4Enabled = checkBoxDns4.Checked;
            Settings.Default.AlterNativeDns6Enabled = checkBoxDns6.Checked;

            Settings.Default.Save();
        }

        public static void TemporaryModifyNetworkInfo(NetworkInfo networkInfo)
        {
            var currentNetworkInfo = GetCurrentNetworkInfo();

            // Modify IPv4 Gateway
            if (networkInfo.Gateway4_enable && !string.IsNullOrEmpty(networkInfo.Gateway4) && networkInfo.Gateway4 != "N/A" && networkInfo.Gateway4 != currentNetworkInfo.Gateway4)
            {
                ExecutePowerShellCommand($"New-NetRoute -DestinationPrefix \"0.0.0.0/0\" -NextHop {networkInfo.Gateway4} -InterfaceIndex (Get-NetAdapter -Physical | Where-Object {{ $_.Status -eq 'Up' }}).ifIndex -PolicyStore \"ActiveStore\"");
                if (currentNetworkInfo.Gateway4 != "N/A")
                {
                    ExecutePowerShellCommand($"Remove-NetRoute -NextHop {currentNetworkInfo.Gateway4} -Confirm:$False");
                }
            }

            // Modify IPv6 Gateway
            if (networkInfo.Gateway6_enable && !string.IsNullOrEmpty(networkInfo.Gateway6) && networkInfo.Gateway6 != "N/A" && networkInfo.Gateway6 != currentNetworkInfo.Gateway6)
            {
                ExecutePowerShellCommand($"New-NetRoute -DestinationPrefix \"::/0\" -NextHop {networkInfo.Gateway6} -InterfaceIndex (Get-NetAdapter -Physical | Where-Object {{ $_.Status -eq 'Up' }}).ifIndex -PolicyStore \"ActiveStore\"");
                if (currentNetworkInfo.Gateway6 != "N/A")
                {
                    ExecutePowerShellCommand($"Remove-NetRoute -NextHop {currentNetworkInfo.Gateway6} -Confirm:$False");
                }
            }

            // Modify IPv4 DNS
            if (networkInfo.Dns4_enable && !string.IsNullOrEmpty(networkInfo.Dns4) && networkInfo.Dns4 != "N/A" && networkInfo.Dns4 != currentNetworkInfo.Dns4)
            {
                ExecutePowerShellCommand($"Set-DnsClientServerAddress -InterfaceIndex (Get-NetAdapter -Physical | Where-Object {{ $_.Status -eq 'Up' }}).ifIndex -ServerAddresses {networkInfo.Dns4}");
            }

            // Modify IPv6 DNS
            if (networkInfo.Dns6_enable && !string.IsNullOrEmpty(networkInfo.Dns6) && networkInfo.Dns6 != "N/A" && networkInfo.Dns6 != currentNetworkInfo.Dns6)
            {
                ExecutePowerShellCommand($"Set-DnsClientServerAddress -InterfaceIndex (Get-NetAdapter -Physical | Where-Object {{ $_.Status -eq 'Up' }}).ifIndex -ServerAddresses {networkInfo.Dns6}");
            }
        }

        private static void ExecutePowerShellCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"{command}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    throw new InvalidOperationException($"Error executing PowerShell command: {error}");
                }
            }
        }
    }
}
