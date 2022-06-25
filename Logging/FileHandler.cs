using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging {
    public class FileHandler {
        public bool IsEnable { get; set; }
        public string LogDirectory { get; set; }
        public string LogName { get; set; }
        public FileMode Mode { get; set; }
        public Level MinLevel { get; set; }
    }
}
