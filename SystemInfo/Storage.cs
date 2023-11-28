using System.Runtime.InteropServices;

namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class SystemInfo
    {
        /// <summary>
        /// Provides methods for getting information about the user's storage.
        /// </summary>
        public static class Storage
        {
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
        }
    }
}