using CitizenFX.Core.Native;
using System;
using System.Diagnostics;

namespace mc_accounts_server.Utility
{
    static class Logger
    {
        public enum LogLevel
        {
            NONE = 0,
            INFO = 1,
            WARN = 2,
            ERROR = 3,
            FATAL = 4
        }

        private static string BuildHeader(LogLevel level, string module)
        {
            if (level == LogLevel.NONE) return DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd H:mm:ss") + " [" + module + "]: ";
            else return DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd H:mm:ss zzz") + " [" + module + "] (" + Enum.GetName(typeof(LogLevel), level) + "): ";
        }

        public static void WriteLog(LogLevel level, string module, string text)
        {
            Debug.WriteLine(BuildHeader(level, module) + text);
        }

        public static void WriteLog(LogLevel level, string text)
        {
            WriteLog(level, API.GetCurrentResourceName(), text);
        }
    }
}
