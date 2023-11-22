using System.Globalization;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Wavestorm.Utilities;

public partial class Utilities
{
    public class SystemInfo
    {
        /// TODO: Implement for other platforms
        /// <summary>
        /// Get the information about the current CPU. Please note that this method is only supported on Windows.
        /// </summary>
        /// <returns>The information about the current CPU.</returns>
        public static string GetCpuInfo()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string cpuInfo = string.Empty;
                using (ManagementClass mc = new ManagementClass("win32_processor"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        if (cpuInfo == string.Empty)
                        {
                            // Get only the first CPU's information
                            cpuInfo = mo.Properties["processorID"].Value.ToString();
                            break;
                        }
                    }
                }

                return cpuInfo;
            }
            else
            {
                throw new PlatformNotSupportedException(
                    "Getting CPU information is not supported on non-Windows platforms.");
            }
        }

        /// <summary>
        /// Gets the number of bytes in the operating system's committed virtual memory.
        /// </summary>
        /// <returns>The number of logical processors in the current system.</returns>
        public static int GetProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        /// Gets the number of bytes in the operating system's committed virtual memory.
        /// </summary>
        /// <returns>The number of bytes in the operating system's committed virtual memory.</returns>
        public static long GetTotalVirtualMemory()
        {
            return Environment.WorkingSet;
        }

        /// <summary>
        /// Calls the Win32 API to get the total physical memory installed on the system.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class MEMORYSTATUSEX
        {
            public uint dwLength;
            public ulong ullTotalPhys;

            public MEMORYSTATUSEX()
            {
                dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        /// TODO: Implement for other platforms
        /// <summary>
        /// Gets the total RAM installed on the system. Please note that this method is only supported on Windows.
        /// </summary>
        /// <returns>The total RAM installed on the system in bytes.</returns>
        public static ulong GetTotalPhysicalMemory()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                MEMORYSTATUSEX memInfo = new MEMORYSTATUSEX();
                GlobalMemoryStatusEx(memInfo);
                return memInfo.ullTotalPhys;
            }
            else
            {
                throw new PlatformNotSupportedException(
                    "Getting total physical memory is not supported on non-Windows platforms.");
            }
        }

        /// TODO: Implement for other platforms
        /// <summary>
        /// Gets the user's GPU (graphics processing unit) names. Please note that this method is only supported on Windows.
        /// </summary>
        /// <returns>The user's GPU names as an array of strings.</returns>
        public static string[] GetGraphicsDeviceNames()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                List<string> gpuNames = new List<string>();

                using (ManagementObjectSearcher searcher =
                       new ManagementObjectSearcher("select * from Win32_VideoController"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            // Remove non-alphanumeric characters from the GPU name
                            string cleanedName = new string(name.Where(char.IsLetterOrDigit).ToArray());
                            gpuNames.Add(cleanedName);
                        }
                    }
                }

                return gpuNames.ToArray();
            }
            else
            {
                throw new PlatformNotSupportedException("Getting GPU names is not supported on non-Windows platforms.");
            }
        }

        /// <summary>
        /// Get the total disk space of the specified drive. If driveName is not specified, get the total disk space of all drives combined.
        /// </summary>
        /// <param name="driveName">The name of the drive. If not specified, get the total disk space of all drives combined.</param>
        /// <returns>The total disk space of the specified drive or all drives combined.</returns>
        public static long GetTotalDiskSpace([Optional] string driveName)
        {
            if (string.IsNullOrEmpty(driveName))
            {
                var totalSpace = DriveInfo.GetDrives()
                    .Where(drive => drive.IsReady)
                    .Sum(drive => drive.TotalSize);

                return totalSpace;
            }
            else
            {
                DriveInfo drive = new DriveInfo(driveName);
                return drive.TotalSize;
            }
        }

        /// <summary>
        /// Gets the name of the operating system running on this computer.
        /// </summary>
        /// <returns>The name of the operating system running on this computer.</returns>
        public static string GetOperatingSystemName()
        {
            return RuntimeInformation.OSDescription;
        }

        /// <summary>
        /// Gets the version of the operating system running on this computer.
        /// </summary>
        /// <returns>The version of the operating system running on this computer.</returns>
        public static string GetOperatingSystemVersion()
        {
            return Environment.OSVersion.VersionString;
        }

        /// <summary>
        /// Gets the architecture of the operating system running on this computer.
        /// </summary>
        /// <returns>The architecture of the operating system running on this computer.</returns>
        public static string GetOperatingSystemArchitecture()
        {
            return RuntimeInformation.OSArchitecture.ToString();
        }

        /// <summary>
        /// Gets the name of the user who is currently logged in.
        /// </summary>
        /// <returns>The name of the user who is currently logged in.</returns>
        public static string GetUserName()
        {
            return Environment.UserName;
        }

        /// <summary>
        /// Gets the name of the computer.
        /// </summary>
        /// <returns>The name of the computer.</returns>
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// Gets the user's language.
        /// </summary>
        /// <returns>The user's language.</returns>
        public static string GetUserLanguage()
        {
            return CultureInfo.CurrentCulture.DisplayName;
        }
        
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <returns>The name of the application.</returns>
        public static string GetApplicationName()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        /// <summary>
        /// Gets the version of the application.
        /// </summary>
        /// <returns>The version of the application.</returns>
        public static string GetApplicationVersion()
        {
            return Assembly.GetEntryAssembly()?.GetName().Version.ToString();
        }
    }
}