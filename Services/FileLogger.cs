namespace rtlog.Services
{
    public class FileLogger : ILogService
    {
        public void Log(string application, string version, string type, string message, string? stackTrace)
        {
            var filePath = GetFilePath(application, version);
            var log = GetLogMessage(message, stackTrace, type);
            File.AppendAllText(filePath, log);
        }

        private string GetLogMessage(string message, string? stackTrace, string type)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            string log = string.Empty;

            log += "-START-----------------------------------\n";
            log += $"message:{message}\n";
            log += $"stackTrace:{stackTrace}\n";
            log += $"type:{type}\n";
            log += $"time:{time}\n";
            log += "-END------------------------------------\n";

            return log;
        }

        private string GetFilePath(string application, string version)
        {
            var currentDateStr = DateTime.Now.ToString("yyyy-MM-dd");
            string filePath = $"logs/{application}-{version}-{currentDateStr}.log";

            if (!File.Exists(filePath))
                File.Create(filePath);

            return filePath;
        }
    }
}
