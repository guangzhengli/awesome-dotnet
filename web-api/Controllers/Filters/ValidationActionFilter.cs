using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Awesome_dotnet.Controllers.Filters;

public class ValidationActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var modelState = context.ModelState;
        if (modelState.IsValid)
        {
            return;
        }

        var errors = modelState.Select(pair => new
        {
            pair.Key,
            pair.Value?.Errors.FirstOrDefault()?.ErrorMessage
        }).ToDictionary(pair => pair.Key, pair => pair.ErrorMessage);
        context.Result = new BadRequestObjectResult(errors);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}