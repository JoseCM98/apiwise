using apiwise.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace apiwise.Helps
{
    public class ManagerException : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ILoggerWise _logger;
        public ManagerException(IWebHostEnvironment webHostEnvironment,
                                IModelMetadataProvider modelMetadataProvider,
                                ILoggerWise logger)
        {
            _logger = logger;
            _hostEnviroment = webHostEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            _ = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            string msn = $"Tipo: {context.Exception.GetType()}, {(context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message)}";
            _logger.LogError($"{actionName} {msn}");
            context.Result = new JsonResult(new ServerRespuesta()
            {
                Success = false,
                Message = msn
            });
        }
    }
}
