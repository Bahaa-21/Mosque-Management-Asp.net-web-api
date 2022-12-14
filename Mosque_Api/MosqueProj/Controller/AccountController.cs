namespace MosqueProj.Controller;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<Users> _userManager;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;



    public AccountController(UserManager<Users> userManager, IMapper mapper, IAuthManager authManager) =>

        (_userManager, _mapper, _authManager) = (userManager, mapper, authManager);


    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserDTO userDOT)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (await _userManager.FindByEmailAsync(userDOT.Email) is not null)
            return BadRequest();

        var user = _mapper.Map<Users>(userDOT);

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
    public async Task<ActionResult<string>> Login([FromBody] LoingUserDTO loingUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (!await _authManager.ValidateUser(loingUser))
        {
            return Unauthorized();
        }
        var token = _authManager.CreateToken();

        return Ok(token);
    }
}
