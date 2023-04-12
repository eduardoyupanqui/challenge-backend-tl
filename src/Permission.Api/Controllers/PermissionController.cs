using MediatR;
using Microsoft.AspNetCore.Mvc;
using Permissions.Api.Application.Commands;
using Permissions.Api.Application.Queries;

namespace Permissions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IMediator _mediator;

        public PermissionController(ILogger<PermissionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all permissions from employee
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-permissions")]
        [ProducesResponseType(typeof(IEnumerable<PermissionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPermissions([FromQuery] int employeeId)
        {
            var result = await _mediator.Send(new GetPermissionsQuery(employeeId));
            return Ok(result);
        }

        /// <summary>
        /// Create permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("request-permission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestPermission(RequestPermissionCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Modify permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("modify-permission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ModifyPermission(ModifyPermissionCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
