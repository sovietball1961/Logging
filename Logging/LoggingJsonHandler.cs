﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logging {
    internal class LoggingJsonHandler {
        internal void LoadJson(string path) {
            using (var sr = new StreamReader(path)) {
                string rawJson = sr.ReadToEnd();
                
            }            
        }
    }
}
