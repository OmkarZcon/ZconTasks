using System;
using System.IO;

namespace OOPTaskDay2
{
    public static class FileLogger
    {
        private static readonly string LogFilePath = "C:\\Users\\OmkarB\\source\\repos\\OOPTaskDay2\\log.txt";

       
        public static void Log(string message)
        {
            try
            {
                // Write the message to the log file with a timestamp
                File.AppendAllText(LogFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during logging
                Console.WriteLine($"Failed to log message: {ex.Message}");
            }
        }
    }
}
