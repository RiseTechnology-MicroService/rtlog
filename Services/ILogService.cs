namespace rtlog.Services
{
    public interface ILogService
    {
        void Log(string application, string version, string type, string message, string? stackTrace);
    }
}
