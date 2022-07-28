using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

using log4net;
namespace WebApplication3.Filter
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(MyExceptionFilter));

        public void OnException(ExceptionContext context)
        {
            string control = context.RouteData.Values["controller"].ToString();
            string act = context.RouteData.Values["action"].ToString();

            _logger.Error("Controller : "+control+" Action : "+act);
            _logger.Error(context.Exception.Message);
            context.ExceptionHandled = true;
            context.Result = new ViewResult() { ViewName = "CustomError" };
        }
    }
}
