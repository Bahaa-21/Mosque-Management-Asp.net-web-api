using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosqueProj.Entities;
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


        [HttpGet(Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents([FromQuery] RequestParams requestParams) 
        {
            var students = await _unitOfWork.Students.GetAll(requestParams);
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
            var student = await _unitOfWork.Students.Get(s => s.Id == id , new[] {"Groups"});
            
            var result = _mapper.Map<StudentDTO>(student);

            return Ok(result);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO studentDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentDTO);
            await _unitOfWork.Students.Insert(student);
            await _unitOfWork.Save();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }


        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateStudent(int id , [FromBody] UpdateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest($"Submitted data is invalid {ModelState}");
            }

            var student = await _unitOfWork.Students.Get(op => op.Id == id);
            if (student is null)
            {
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(studentDTO,student);
            _unitOfWork.Students.Update(student);
            await _unitOfWork.Save();
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var group = await _unitOfWork.Students.Get(g => g.Id == id);
            if (group is null)
            {
                return BadRequest();
            }
            await _unitOfWork.Students.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

    }
}
