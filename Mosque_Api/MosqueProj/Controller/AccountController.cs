using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MosqueProj.Entities;
using MosqueProj.Model;
using MosqueProj.Services;
using System;
using System.Threading.Tasks;

namespace MosqueProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUsers> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        


        public AccountController(UserManager<ApiUsers> userManager, IMapper mapper , IAuthManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
        }



        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _userManager.FindByEmailAsync(userDOT.Email) is not null)
                return BadRequest();

            var user = _mapper.Map<ApiUsers>(userDOT);

            user.UserName = userDOT.Email;

            var result = await _userManager.CreateAsync(user, userDOT.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userDOT.Roles);
            return Accepted();
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoingUserDTO loingUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authManager.ValidateUser(loingUser))
            {
                return Unauthorized();
            }

            return Ok(new { token = _authManager.CreateToken() });
        }
    }
}
