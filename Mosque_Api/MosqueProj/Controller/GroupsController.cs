using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosqueProj.Model;
using MosqueProj.IReprository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MosqueProj.Entities;
using System;

namespace MosqueProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _unitOfWork.Groups.GetAll(g => g.YearId > 0);

            var results = _mapper.Map<IList<GroupDTO>>(groups);
            return Ok(results);
        }


        [HttpGet("{id:int}" , Name = "GetGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroup(int id)
        {

            var group = await _unitOfWork.Groups.Get(g => g.Id==id , new[] { "Students" });
            var result = _mapper.Map<GroupDTO>(group);
            return Ok(group);
        }
        
        //[Authorize(Roles = "Adminsitrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDTOS createGroupDTOS)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = _mapper.Map<Group>(createGroupDTOS);
            await _unitOfWork.Groups.Insert(group);
            
            await _unitOfWork.Save();
            
            return CreatedAtAction("GetGroup" , new {id = group.Id} ,  new {group.Id , group.NameGroup , group.Min_Old , group.Max_Old,group.YearId});

        }

        //[Authorize(Roles = "Adminsitrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGroup(int id , [FromBody] UpdateGroupDTOS GroupDTOS)
        {
            if(!ModelState.IsValid || id < 1)
            {
                return BadRequest($"Submitted data is invalid {ModelState}");
            }
            var group = await  _unitOfWork.Groups.Get(g=>g.Id==id);
            if (group is null)
            {
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(GroupDTOS,group);
            _unitOfWork.Groups.Update(group);
            await _unitOfWork.Save();
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var group = await _unitOfWork.Groups.Get(g=>g.Id==id);  
            if(group is null)
            {
                return BadRequest();
            }
            await _unitOfWork.Groups.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
