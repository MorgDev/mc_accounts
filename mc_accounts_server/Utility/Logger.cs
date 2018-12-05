using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
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


        private static readonly Dictionary<string, string> Colors = new Dictionary<string, string>()
        {
            { "red", "^1" },
            { "green", "^2" },
            { "orange", "^3" },
            { "blue", "^4" },
            { "lightblue", "^5" },
            { "purple", "^6" },
            { "white", "^7" }
        };

        private static string BuildHeader(LogLevel level, string module)
        {
            if (level == LogLevel.NONE) return Colors["orange"] + DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd H:mm:ss") + Colors["lightblue"] + " [" + module + "]: " + Colors["white"];
            else return Colors["orange"] + DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd H:mm:ss zzz") + Colors["lightblue"] + " [" + module + "] (" + Enum.GetName(typeof(LogLevel), level) + "): " + Colors["white"];
        }

        public static void WriteLog(LogLevel level, string module, string text, string color)
        {
            string col = Colors.ContainsKey(color) ? color : "";

            Debug.WriteLine(BuildHeader(level, module) + Colors[col] + text);
        }

        public static void WriteLog(LogLevel level, string text, string color)
        {
            WriteLog(level, API.GetCurrentResourceName(), text, color);
        }
    }
}
