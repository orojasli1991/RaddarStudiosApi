using Microsoft.AspNetCore.Mvc;
using StudentManagementInterRapidisimo.Domain.Entities;
using StudentManagementInterRapidisimo.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentManagementInterRapidisimo.Dao.Persitence;
using StudentManagementInterRapidisimo.Application.Services;

namespace StudentManagementInterRapidisimo.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly DbContext _context; 

        public SubjectController(ISubjectService subjectService, ApplicationDbContext context)
        {
            _subjectService = subjectService;
            _context = context;

        }
        [HttpGet("GetAllSubject")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            var subjects = await _subjectService.GetAllSubjects();
            return Ok(subjects.ToArray());
        }
        [HttpPost("SaveSelection")]
        public async Task<ActionResult> SaveSelection([FromBody] List<SubjectSelection> selectedSubjects)
        {
            await _subjectService.SaveSelection(selectedSubjects);
            return Ok();
        }
        [HttpPost("{studentId}/GetStudentsBySubjects")]
        public async Task<ActionResult> GetStudentsBySubjects(int studentId, [FromBody] List<int> subjectIds)
        {
      
            var classmates =  _subjectService.GetStudentsBySubject(studentId, subjectIds);

            if (classmates == null || !classmates.Any())
            {
                return NotFound("No hay compañeros en esta clase.");
            }

            return Ok(classmates.ToArray());
        }
        [HttpGet("{studentId}/GetSubjectsByStudent")]
        public async Task<ActionResult> GetSubjectsByStudent(int studentId)
        {
            var subjects = _subjectService.GetSubjectsByStudent(studentId);

            if (subjects == null || !subjects.Any())
            {
                return NotFound("El estudiante no tiene materias asignadas.");
            }

            return Ok(subjects.ToArray());
        }
    }
}