using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands.UserRegistration;
using TaskManagement.Application.Queries.GetUserByParamsQuery;
using TaskManagement.Application.Queries.UserQuery;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator=mediator;

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserRegistrationCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }

        [HttpGet]
        public async Task<ActionResult> GetUserById(int id)
        {
            var task = await _mediator.Send(new GetUserByParamsQuery { UserId = id });
            return task == null ? NotFound() : Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var userList = await _mediator.Send(new UserQuery());
            return userList == null ? NotFound() : Ok(userList);
        }
    }
}
