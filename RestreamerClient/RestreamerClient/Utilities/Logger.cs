using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestreamerClient.Utilities
{
    public static class Logger
    {
        private static readonly string LogFilePath = "logs/streamer.log";

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        private static void Write(string level, string message)
        {
            var logLine = $"[{DateTime.Now}] [{level}] {message}";
            Directory.CreateDirectory("logs");
            File.AppendAllText(LogFilePath, logLine + Environment.NewLine);
        }
    }
}
