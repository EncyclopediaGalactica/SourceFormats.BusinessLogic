namespace EncyclopediaGalactica.Services.Document.SourceFormatsService.ExceptionFilters;

using System.Net;
using EncyclopediaGalactica.Utils.GuardsService.Exceptions;
using FluentValidation;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

public class ValidationExceptionsFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is ArgumentNullException
            or ValidationException
            or DbUpdateException
            or GuardsServiceValueShouldNotBeEqualToException)
        {
            context.Result = new ObjectResult(SourceFormatsServiceResultStatuses.ValidationError)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
            context.ExceptionHandled = true;
        }
    }
}