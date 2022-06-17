using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging;

namespace LoggingDebugger {
    internal class Program {
        static void Main(string[] args) {
            var logger = new Logger() {
                Formatter = new Formatter {
                    Format = "{asctime} [{level}] {message}",
                    DateFormat = "yy-MM-dd hh:mm:ss"
                },
                StreamHandler = new StreamHandler {
                    MinLevel = Level.Debug
                },
                FileHandler = new FileHandler {
                    FilePath = "/var/log/foo.log",
                    MinLevel = Level.Debug,
                    Mode = FileMode.Open,
                }
            };
            logger.Critical("WE'LL BE RIGHT BACK");
            Console.ReadKey();
        }
    }
}