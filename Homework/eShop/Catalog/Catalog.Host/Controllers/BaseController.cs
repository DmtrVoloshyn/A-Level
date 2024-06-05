using System.Net.Mime;
using Catalog.Host.Models.Response;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
[Produces(MediaTypeNames.Application.Json)]
[ProducesErrorResponseType(typeof(WebApiErrorResponse))]
public abstract class BaseController : ControllerBase
{
    protected IActionResult WebApiErrorResponse(WebApiErrorResponse errorResponse)
        => StatusCode(errorResponse.Code, new WebApiErrorResponse(errorResponse.Code, errorResponse.SubCode, errorResponse.Description));
}