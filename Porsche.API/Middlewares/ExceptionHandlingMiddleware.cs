using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Exceptions;

namespace Porsche.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var code = StatusCodes.Status500InternalServerError;

            switch (e)
            {
                case EntityNotFoundException entityNotFoundException:
                    code = StatusCodes.Status404NotFound;
                    break;
                case AuthenticationException authenticationException:
                    code = StatusCodes.Status401Unauthorized;
                    break;
                default:
                    code = StatusCodes.Status500InternalServerError;
                    break;
            }
            
            _logger.LogError(e, "Exception occurred: {Message}", e.Message);
            var problemDetails = new ProblemDetails()
            {
                Status = code,
                Title = e.Message,
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}