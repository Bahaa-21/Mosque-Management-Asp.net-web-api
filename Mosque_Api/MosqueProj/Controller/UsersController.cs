using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosqueProj.Model;

namespace MosqueProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;



        public UsersController(UserManager<Users> userManager, IMapper mapper, IAuthManager authManager , IUnitOfWork unitOfWork) =>

            (_userManager, _mapper, _authManager,_unitOfWork) = (userManager, mapper, authManager,unitOfWork);



 
        [HttpGet("get-user-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null || user.Id != id)
                return BadRequest("Submitted data is invalid");

            return Ok(_mapper.Map<UserDTO>(user));
        }

    }
}
