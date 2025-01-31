using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace GateSwitchWay
{
    internal class AppAutoStart
    {
        // Retrie assembly name to use as the task name
        public static readonly string taskName = Assembly.GetExecutingAssembly().GetName().Name ?? "GateSwitchWay";
        private static readonly string exePath = Assembly.GetExecutingAssembly().Location.Replace("\\", "\\\\");

        public static bool SetAutoStart(bool enable)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "schtasks.exe",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            // create or delete task based on `enable` parameter
            startInfo.Arguments = enable ? $"/Create /F /RL HIGHEST /SC ONLOGON /TN \"{taskName}\" /TR \"'{exePath}'\"" : $"/Delete /F /TN \"{taskName}\"";

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine($"Command exited with code {process.ExitCode}");
                        return false;
                    }
                    else
                    {
                        // success return
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing task: {ex.Message}");
            }
            return false;
        }

        public static bool GetAutoStart()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "schtasks.exe",
                Arguments = $"/Query /TN \"{taskName}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"Error querying task: {error}");
                        return false; // Assuming the task does not exist if an error occurred
                    }

                    return !output.Contains("ERROR: The system cannot find the file specified.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying task: {ex.Message}");
                return false;
            }
        }
    }
}
