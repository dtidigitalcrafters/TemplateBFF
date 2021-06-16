namespace TemplateBFF.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using TemplateBFF.Domain;

    public sealed class NotFoundExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 404,
                    Title = "Not Found",
                    Detail = context.Exception.Message,
                };

                context.Result = new NotFoundObjectResult(problemDetails);
                context.Exception = null;
            }
        }
    }
}