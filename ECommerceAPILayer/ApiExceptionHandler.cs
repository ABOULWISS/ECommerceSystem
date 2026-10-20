



using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPILayer{

    public sealed class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context, Exception ex, CancellationToken ct)
        {
            var (status, title) = ex switch
            {
                ArgumentException       => (StatusCodes.Status400BadRequest, "Invalid request"),
                KeyNotFoundException    => (StatusCodes.Status404NotFound,   "Not found"),
                InvalidOperationException => (StatusCodes.Status409Conflict, "Conflict"),
                _                       => (StatusCodes.Status500InternalServerError, "Server error")
            };
    
            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = status,
                Title = title,
                // Don't leak internals on 500s
                Detail = status == StatusCodes.Status500InternalServerError ? null : ex.Message
            }, ct);
    
            return true;
        }
    }
}