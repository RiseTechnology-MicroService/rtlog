using Microsoft.AspNetCore.Mvc;
using rtlog.Services;

namespace rtlog.Controllers
{
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public void Post([FromBody] CreateLogModel model)
        {
            _logService.Log(model.Application, model.Version, model.Type, model.Message, model.StackTrace);
        }
    }

    public class CreateLogModel
    {
        public string Application { get; set; }
        public string Version { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        public string Type { get; set; }

        public CreateLogModel(string application, string version, string type, string message, string? stackTrace)
        {
            Application = application;
            Version = version;
            Type = type;
            Message = message;
            StackTrace = stackTrace;
        }
    }
}
