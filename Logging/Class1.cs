using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging {
    public class Logger {
        public Formatter Formatter { get; set; }
        public FileHandler FileHandler { get; set; }
        public StreamHandler StreamHandler { get; set; }

        public void Critical(string message, ConsoleColor color = ConsoleColor.White) =>
            LoggerCommon(Level.Critical, message, color);

        public void Error(string message, ConsoleColor color = ConsoleColor.White) =>
            LoggerCommon(Level.Error, message, color);

        public void Warning(string message, ConsoleColor color = ConsoleColor.White) =>
            LoggerCommon(Level.Warning, message, color);

        public void Info(string message, ConsoleColor color = ConsoleColor.White) =>
            LoggerCommon(Level.Info, message, color);

        public void Debug(string message, ConsoleColor color = ConsoleColor.White) =>
            LoggerCommon(Level.Debug, message, color);

        private void LoggerCommon(Level level, string message, ConsoleColor color) {
            string logMessage = this.Formatter.BuildLogMessage(level, message);

            if (this.StreamHandler.MinLevel > level) {
                Console.ForegroundColor = color;
                Console.WriteLine(logMessage);
                Console.ResetColor();
            }
            if (this.FileHandler.MinLevel > level) {
                using(FileStream fs = new FileStream(this.FileHandler.FilePath, this.FileHandler.Mode)) {

                }
            }
        }
    }

    public class Formatter {
        public string Format { get; set; }
        public string DateFormat { get; set; }

        public string BuildLogMessage(Level level, string message) {
            string logMsg = this.Format;

            if (Regex.IsMatch(this.Format, @"{asctime}")){
                logMsg = Regex.Replace(logMsg, @"{asctime}", DateTime.Now.ToString(this.DateFormat));
            }
            if (Regex.IsMatch(this.Format, @"{level}")){
                logMsg = Regex.Replace(logMsg, @"{level}", level.ToString());
            }
            if (Regex.IsMatch(this.Format, @"{message}")){
                logMsg = Regex.Replace(logMsg, @"{message}", message);
            }

            return logMsg;
        }
    }

    public class StreamHandler {
        public bool IsEnable { get; set; }
        public Level MinLevel { get; set; }
    } 

    public class FileHandler {
        public bool IsEnable { get; set; }
        public string FilePath { get; set; }
        public FileMode Mode { get; set; }
        public Level MinLevel { get; set; }
    }

    public enum Level {
        Critical,
        Error,
        Warning,
        Info,
        Debug           
    }
}