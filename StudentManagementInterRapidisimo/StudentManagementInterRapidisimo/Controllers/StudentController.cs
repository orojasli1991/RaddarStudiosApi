using Microsoft.AspNetCore.Mvc;
using StudentManagementInterRapidisimo.Application.Services;
using StudentManagementInterRapidisimo.Application.Dto;
using StudentManagementInterRapidisimo.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementInterRapidisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService studentService)
        {
            _service = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAll()
        {
            var student = await _service.GetAllAsync();
            return Ok(student.ToArray());
        }
        [HttpGet("GetStudentId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            await _service.AddAsync(studentDto);
            return CreatedAtAction(nameof(GetById), new { id = studentDto.Id }, studentDto);
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto studentDto)
        {
            if (id != studentDto.Id) return BadRequest();
            await _service.UpdateAsync(studentDto);
            return NoContent();
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}

