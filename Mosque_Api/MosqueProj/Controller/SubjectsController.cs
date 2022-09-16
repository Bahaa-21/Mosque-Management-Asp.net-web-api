namespace MosqueProj.Controller;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubjectsController(IUnitOfWork unitOfWork, IMapper mapper) =>
        (_unitOfWork, _mapper) = (unitOfWork, mapper);
    

    [HttpPost]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<CreateSubjectDTO> subjectDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest();


        var subject =_mapper.Map<IList<Subject>>(subjectDTO);
        await _unitOfWork.Subjects.InsertRange(subject);
        await _unitOfWork.Save();

        return Ok();
    }
}
