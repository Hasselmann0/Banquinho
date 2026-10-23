using Banquinho.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Banquinho.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var (status, title) = ex switch
            {
                ValidationException => (400, "Dados inválidos"),
                NotFoundException => (404, "Recurso não encontrado"),
                BusinessRuleException => (409, "Regra de negócio violada"),
                _ => (500, "Erro interno")
            };
            if (status == 500) _logger.LogError(ex, "Erro não tratado");
            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = status == 500 ? null : ex.Message
            });
        }
    }
}
