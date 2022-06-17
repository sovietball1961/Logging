using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging {
    public class Formatter {
        private string format;
        private string dateFormat;

        public string BuildLogMessage(Level level, string message) {
            string logMsg = format;

            if (Regex.IsMatch(format, @"{asctime}")) {
                logMsg = Regex.Replace(logMsg, @"{asctime}", DateTime.Now.ToString(dateFormat));
            }
            if (Regex.IsMatch(format, @"{level}")) {
                logMsg = Regex.Replace(logMsg, @"{level}", level.ToString());
            }
            if (Regex.IsMatch(format, @"{message}")) {
                logMsg = Regex.Replace(logMsg, @"{message}", message);
            }

            return logMsg;
        }

        public string Format {
            set {
                if (string.IsNullOrEmpty(value)) {
                    format = value;
                }
                else {
                    throw new ArgumentException();
                }
            }
        }

        public string DateFormat {
            set { dateFormat = value; }
        }
    }
}
