namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.ExceptionFilters;

using System.Net;
using Interfaces;
using Mappers.Exceptions.SourceFormatNode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SourceFormatsCacheService.Exceptions;
using SourceFormatsRepository.Exceptions;

public class InternalServerErrorExceptionsFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is SourceFormatNodeRepositoryException
            or DbUpdateConcurrencyException)
        {
            context.Result = new ObjectResult(SourceFormatsServiceResultStatuses.InternalError)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}