﻿using System;
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
                Formatter = null
            };
        }
    }
}