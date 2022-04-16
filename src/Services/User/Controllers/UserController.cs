using User.Application.Commands;
using User.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Seedwork.CommandHandler;
using User.Application.Queries;

namespace User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IUserQueries _userQueries;

        public UserController(
            ILogger<UserController> logger,
            IMediator mediator,
            IUserQueries userQueries)
        {
            _logger = logger;
            _mediator = mediator;
            _userQueries = userQueries;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userQueries.GetAllUser();
            return Ok(users);
        }

        /// <summary>
        /// Get user by Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userQueries.GetUser(id);
            return Ok(user);
        }

        /// <summary>
        /// Update user data.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateViewModel dto)
        {
            return Ok();
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}