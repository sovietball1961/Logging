using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging {
    public class Formatter {
        private static string format;
        private static string dateFormat;

        internal string BuildLogMessage(Level level, string message) {
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

        public static string Format {
            set {
                if (string.IsNullOrEmpty(value)) {
                    var err = LoggerError.Status.FormatNotDefined;
                    var msg = err.GetStatusInfo();
                    var cod = err.GetStatusCode();
                    throw new FormatException($"{msg} code:{cod}");
                }
                else {
                    format = value;
                }
            }
        }

        public static string DateFormat {
            set {
                if (string.IsNullOrEmpty(value)) {
                    var err = LoggerError.Status.NemuikedoNerenai;
                    var msg = err.GetStatusInfo();
                    var cod = err.GetStatusCode();
                    throw new FormatException($"{msg} code:{cod}");
                }
                else {
                    dateFormat = value;
                }
            }
        }
    }
}
