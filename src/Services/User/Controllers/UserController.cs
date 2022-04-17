using User.Application.Commands;
using User.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using User.Application.Queries;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<IActionResult> Login(AuthViewModel authViewModel)
        {
            var usuario = await _userQueries.Auth(authViewModel.Email, authViewModel.Password);

            if (usuario == null) return BadRequest("Nâo foi possível logar no sistema.");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Name),
                new Claim(ClaimTypes.Role, usuario.AccessType),
                new Claim(ClaimTypes.NameIdentifier, usuario.Login.ToString())
            };

            usuario.AccessType = GerarJwt(claims);
            return Ok(usuario);
        }

        public static string GerarJwt(IEnumerable<Claim> permissoes)
        {
            var key = Encoding.ASCII.GetBytes("chave");
            var jwt = new JwtSecurityToken(
                issuer: "boaentrega",
                audience: "boaentrega",
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                claims: permissoes);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
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