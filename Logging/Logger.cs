using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging {
    public class Logger {
        private Formatter formatter;
        private FileHandler fileHandler;
        private StreamHandler streamHandler;

        public Formatter Formatter {
            set {
                formatter = value.GetType() == typeof(Formatter) ? value : null;
            }
        } 
        public FileHandler FileHandler {
            set {
                fileHandler = value.GetType() == typeof(FileHandler) ? value : null;
            }
        }
        public StreamHandler StreamHandler {
            set {
                streamHandler = value.GetType() == typeof(StreamHandler) ? value : null;
            }
        }

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
            string logMessage = this.formatter.BuildLogMessage(level, message);

            void StreamConsole() {
                Console.ForegroundColor = color;
                Console.WriteLine(logMessage);
                Console.ResetColor();
            }
            void StreamFile() {
                bool isAppend = this.fileHandler.Mode == FileMode.Append ? true : false;
                using (StreamWriter writer = new StreamWriter(this.fileHandler.LogName, isAppend)) {
                    
                }
            }
            if (this.streamHandler.MinLevel > level) {
                StreamConsole();
            }
            if (this.fileHandler.MinLevel > level) {
                StreamFile();
            }
        }
    }
}