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
            var teachers = await _unitOfWork.Teachers.GetAll(requestParams, new[]{"Subjects"});

            var results = _mapper.Map<IList<TeacherDTO>>(teachers);

            return Ok(results);
        }

        [HttpGet("get-teacher-by-id/{id}", Name ="GetTeacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeacher(int id)
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


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDTO teacherDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var teacher = _mapper.Map<Teacher>(teacherDTO);
        await _unitOfWork.Teachers.Insert(teacher);

        await _unitOfWork.Save();

        return CreatedAtAction("GetTeacher", new { id = teacher.Id } , teacher);
        
    }

        
        [HttpPut("update-teacher/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] UpdateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest($"Submitted data is invalid {ModelState}");
            }
            var teacher = await _unitOfWork.Teachers.Get(g => g.Id == id);
            if (teacher is null)
            {
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(teacherDTO, teacher);
            _unitOfWork.Teachers.Update(teacher);
            await _unitOfWork.Save();
            return NoContent();

        }
    }
}