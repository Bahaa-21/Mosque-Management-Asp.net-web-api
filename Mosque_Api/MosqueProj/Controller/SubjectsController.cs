namespace MosqueProj.Controller;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubjectsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
        
    [Authorize(Roles = "Adminsitrator")]
    [HttpGet]
    public async Task<IActionResult> GetSubjects([FromQuery] RequestParams requestParams) 
    {
        var subjects = await _unitOfWork.Subjects.GetAll(requestParams , new[] {"Teachers"});

        var result = _mapper.Map<IList<SubjectDTO>>(subjects);

        return Ok(result);
    }





    [HttpPost]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<CreateSubjectDTO> subjectDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest();


        var subjects =_mapper.Map<IList<Subject>>(subjectDTO);
        await _unitOfWork.Subjects.InsertRange(subjects);
        await _unitOfWork.Save();

        return Ok();
    }
}
