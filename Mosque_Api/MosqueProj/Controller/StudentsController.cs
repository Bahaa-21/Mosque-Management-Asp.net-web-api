using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosqueProj.IReprository;
using MosqueProj.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MosqueProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentsController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _unitOfWork.Students.GetAll(expression: null);
            var result = _mapper.Map<IList<StudentDTO>>(students);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name ="GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudent(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var student = await _unitOfWork.Students.Get(s => s.Id == id);
            var result = _mapper.Map<StudentDTO>(student);
            return Ok(result);
        }
    }
}
