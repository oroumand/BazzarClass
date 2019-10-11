using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazzar.EndPoints.API.Services
{
    public static class RequestHandler
    {
        public static IActionResult HandleRequest<T>(T request, Action<T> handler)
        {
            try
            {
                //LogStart
                handler(request);
                return new OkResult();
            }
            catch (Exception e)
            {
                //Log Exception
                return new BadRequestObjectResult(new
                {
                    error =
                    e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
    }
}
