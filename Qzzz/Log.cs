using System.Reflection;

using log4net;

namespace Qzzz
{
    public class Log
    {
        private static ILog _fileLogger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Error(string msg)
        {
            _fileLogger.Error(msg);
        }

        public static void Debug(string msg)
        {
            _fileLogger.Debug(msg);
        }

        public static void Info(string msg)
        {
            _fileLogger.Info(msg);
        }

        public static void Warn(string msg)
        {
            _fileLogger.Warn(msg);
        }

        public static void Fatal(string msg)
        {
            _fileLogger.Fatal(msg);
        }
    }
}
