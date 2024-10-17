using Microsoft.AspNetCore.Diagnostics;

namespace WebApi
{
    class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellation
        )
        {
            var error = new { message = exception.Message };
            await context.Response.WriteAsJsonAsync(error, cancellation);
            return true;
        }
    }
}
