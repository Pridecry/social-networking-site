using Microsoft.AspNetCore.Mvc.Filters;

namespace DieteticSNS.WebAPI.Models
{
    public class ExceptionMessageModel
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ExceptionMessageModel(ExceptionContext context)
        {
            Message = context.Exception.Message;
            StackTrace = context.Exception.StackTrace;
        }
    }
}
