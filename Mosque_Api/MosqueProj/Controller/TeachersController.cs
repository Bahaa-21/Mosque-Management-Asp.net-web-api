namespace MosqueProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeachersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

        [HttpGet("get-all-teachers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeachers([FromQuery] RequestParams requestParams)
        {
            var teachers = await _unitOfWork.Teachers.GetAll(requestParams);

            var results = _mapper.Map<IList<TeacherDTO>>(teachers);

            return Ok(results);
        }

        [HttpGet("get-teacher-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeachers(int id)
        {
            var teachers = await _unitOfWork.Teachers.Get(te => te.Id==id , new[] {"Subjects"});

            var results = _mapper.Map<TeacherDTO>(teachers);

            return Ok(results);
        }
        
        [HttpGet("get-teacher-with-groups-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeacherWithGroups(int id)
        {
            var teachers = await _unitOfWork.GroupsTeachers.Get(te => te.TeacherId==id , new[] {"Teachers" ,"Groups"});

            var results = _mapper.Map<GroupTeachersDTO>(teachers);

            return Ok(results);
        }
    }
}