using System.Net.Mime;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
[Produces(MediaTypeNames.Application.Json)]
[ProducesErrorResponseType(typeof(WebApiErrorResponse))]
public abstract class BaseController : ControllerBase;