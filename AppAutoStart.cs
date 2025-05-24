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
        // Retrieve assembly name to use as the task name
        public static readonly string taskName = Assembly.GetExecutingAssembly().GetName().Name ?? "GateSwitchWay";
        // override file name to use .exe extension
        private static readonly string exePath = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".exe").Replace("\\", "\\\\");

        public static bool SetAutoStart(bool enable)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "schtasks.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            startInfo.Arguments = enable
                ? $"/Create /F /RL HIGHEST /SC ONLOGON /TN \"{taskName}\" /TR \"'{exePath}'\""
                : $"/Delete /F /TN \"{taskName}\"";

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine($"Command exited with code {process.ExitCode}");
                        Console.WriteLine($"Error: {error}");
                        return false;
                    }
                    else if (enable)
                    {
                        // Create an XML file with the updated task settings to properly remove the time limit
                        string tempXmlPath = Path.Combine(Path.GetTempPath(), $"{taskName}_task.xml");
                        var psExport = new ProcessStartInfo
                        {
                            FileName = "powershell.exe",
                            Arguments = $"-NoProfile -Command \"Export-ScheduledTask -TaskName '{taskName}' | Out-File -FilePath '{tempXmlPath}'\"",
                            CreateNoWindow = true,
                            UseShellExecute = false
                        };

                        using (var psProcess = Process.Start(psExport))
                        {
                            psProcess.WaitForExit();
                        }

                        if (File.Exists(tempXmlPath))
                        {
                            try
                            {
                                var xmlDoc = new System.Xml.XmlDocument();
                                xmlDoc.Load(tempXmlPath);

                                var nsManager = new System.Xml.XmlNamespaceManager(xmlDoc.NameTable);
                                nsManager.AddNamespace("ns", "http://schemas.microsoft.com/windows/2004/02/mit/task");

                                // Find the Settings node
                                var settingsNode = xmlDoc.SelectSingleNode("//ns:Settings", nsManager);
                                if (settingsNode != null)
                                {
                                    // Update or create ExecutionTimeLimit
                                    var executionTimeLimit = xmlDoc.SelectSingleNode("//ns:ExecutionTimeLimit", nsManager);
                                    if (executionTimeLimit != null)
                                    {
                                        executionTimeLimit.InnerText = "PT0S";
                                    }
                                    else
                                    {
                                        var newElement = xmlDoc.CreateElement("ExecutionTimeLimit", nsManager.LookupNamespace("ns"));
                                        newElement.InnerText = "PT0S";
                                        settingsNode.AppendChild(newElement);
                                    }

                                    // Update IdleSettings
                                    var idleSettings = xmlDoc.SelectSingleNode("//ns:IdleSettings", nsManager);
                                    if (idleSettings != null)
                                    {
                                        // Remove Duration and WaitTimeout if they exist
                                        var duration = idleSettings.SelectSingleNode("ns:Duration", nsManager);
                                        if (duration != null)
                                        {
                                            idleSettings.RemoveChild(duration);
                                        }

                                        var waitTimeout = idleSettings.SelectSingleNode("ns:WaitTimeout", nsManager);
                                        if (waitTimeout != null)
                                        {
                                            idleSettings.RemoveChild(waitTimeout);
                                        }
                                    }

                                    // Update other settings
                                    var disallowStartIfOnBatteries = xmlDoc.SelectSingleNode("//ns:DisallowStartIfOnBatteries", nsManager);
                                    if (disallowStartIfOnBatteries != null)
                                    {
                                        disallowStartIfOnBatteries.InnerText = "false";
                                    }

                                    var stopIfGoingOnBatteries = xmlDoc.SelectSingleNode("//ns:StopIfGoingOnBatteries", nsManager);
                                    if (stopIfGoingOnBatteries != null)
                                    {
                                        stopIfGoingOnBatteries.InnerText = "false";
                                    }

                                    var allowHardTerminate = xmlDoc.SelectSingleNode("//ns:AllowHardTerminate", nsManager);
                                    if (allowHardTerminate != null)
                                    {
                                        allowHardTerminate.InnerText = "true";
                                    }
                                }

                                xmlDoc.Save(tempXmlPath);

                                // Import the modified XML file
                                var psImport = new ProcessStartInfo
                                {
                                    FileName = "schtasks.exe",
                                    Arguments = $"/Create /F /TN \"{taskName}\" /XML \"{tempXmlPath}\"",
                                    CreateNoWindow = true,
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true
                                };

                                using (var importProcess = Process.Start(psImport))
                                {
                                    string importOutput = importProcess.StandardOutput.ReadToEnd();
                                    string importError = importProcess.StandardError.ReadToEnd();
                                    importProcess.WaitForExit();

                                    if (importProcess.ExitCode != 0)
                                    {
                                        Console.WriteLine($"Task import error: {importError}");
                                        return false;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error modifying task XML: {ex.Message}");
                                return false;
                            }
                            finally
                            {
                                try { File.Delete(tempXmlPath); } catch { /* Ignore cleanup errors */ }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to export task XML");
                            return false;
                        }
                    }
                    return true;
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
