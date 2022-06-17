using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging {
    public class Logger {
        public Formatter Formatter {
            private get; set; 
        }
        public FileHandler FileHandler {
            private get; set; 
        }
        public StreamHandler StreamHandler {
            private get; set;
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
            string logMessage = this.Formatter.BuildLogMessage(level, message);

            void StreamConsole() {
                Console.ForegroundColor = color;
                Console.WriteLine(logMessage);
                Console.ResetColor();
            }
            void StreamFile() {
                using(FileStream fs = new FileStream(this.FileHandler.FilePath, this.FileHandler.Mode)) {

                }
            }
            if (this.StreamHandler.MinLevel > level) {
                StreamConsole();
            }
            if (this.FileHandler.MinLevel > level) {
                StreamFile();
            }
        }
    }
}