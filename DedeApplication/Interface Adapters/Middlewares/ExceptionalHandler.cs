using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DedeApplication.InterfaceAdapters
{
    public class ExceptionalHandler : Exception
    {
        private RequestDelegate _next; 

        public ExceptionalHandler(RequestDelegate next)
        {
            _next = next; 
        }

        public async Task Invoke(HttpContext httpContext) {
                try {
                    await _next(httpContext);
                }

                catch(BadHttpRequestException badHttpRequestException) {
                var ResponseExcpetion = httpContext.Response; 
                ExceptionDTO exceptionDTO = new ExceptionDTO {
                    Message = badHttpRequestException.Message, 
                    StatusCode = badHttpRequestException.StatusCode,
                    StackTrace = badHttpRequestException.StackTrace
                }; 

                ResponseExcpetion.ContentType = "application/json"; 
                ResponseExcpetion.StatusCode = exceptionDTO.StatusCode; 
                await ResponseExcpetion.WriteAsJsonAsync(exceptionDTO);


                }


               


        

    }


    
}

}