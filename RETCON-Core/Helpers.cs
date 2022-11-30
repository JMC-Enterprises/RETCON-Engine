using System;

namespace RETCON.Core
{
    public enum OS
    {
        Windows,
        MacOS,
        Linux
    }

    public static class OSHelper
    {
        public static OS GetOS()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return OS.Windows;
            if (Environment.OSVersion.Platform == PlatformID.MacOSX)
                return OS.MacOS;
            return OS.Linux;
        }

        public static string GetCurrentUserName()
        {
            return Environment.UserName;
        }

        public static bool Is64BitSystem()
        {
            return Environment.Is64BitOperatingSystem;
        }
    }

    public static class FunctionHelpers
    {
	    public static int Bit(int x)
        {
            return 1 << x;
        }
    }
}
