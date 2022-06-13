using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging;

namespace LoggingDebugger {
    internal class Program {
        static void Main(string[] args) {
            var logger = new Logger() {
                Formatter = new
            };
            logger.Critical("WE'LL BE RIGHT BACK");
            Console.ReadKey();
        }
    }
}