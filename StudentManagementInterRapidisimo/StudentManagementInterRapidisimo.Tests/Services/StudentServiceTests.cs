using NUnit.Framework;
using Moq;
using StudentManagementInterRapidisimo.Application.Services;
using StudentManagementInterRapidisimo.Domain.Entities;
using StudentManagementInterRapidisimo.Domain.Interfaces;
using AutoMapper;
using StudentManagementInterRapidisimo.Application.Dto;
using StudentManagementInterRapidisimo.Application.Interfaces;
using StudentManagementInterRapidisimo.Dao.Repositories;

namespace StudentManagement.Tests.Services
{
    [TestFixture]
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _studentRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private IStudentService _studentService;

        [SetUp]
        public void SetUp()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _mapperMock = new Mock<IMapper>();
            _studentService = new StudentService(_studentRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetAllStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Oscar Rojas" },
                new Student { Id = 2, Name = "Sandra Ramos" }
            };

            _studentRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(students);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<StudentDto>>(It.IsAny<IEnumerable<Student>>()))
                .Returns((IEnumerable<Student> src) => src.Select(s => new StudentDto { Id = s.Id, Name = s.Name }));
            var result = await _studentService.GetAllAsync();
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo("Oscar Rojas"));
        }

        [Test]
        public async Task GetStudentById()
        {

            var student = new Student { Id = 1, Name = "Oscar Rojas" };
            _studentRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(student);
            _mapperMock.Setup(mapper => mapper.Map<StudentDto>(It.IsAny<Student>()))
                .Returns((Student src) => new StudentDto { Id = src.Id, Name = src.Name });
            var result = await _studentService.GetByIdAsync(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Oscar Rojas"));
        }

        [Test]
        public async Task GetStudentByIdIsNull()
        {
            _studentRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Student)null);
            var result = await _studentService.GetByIdAsync(99);
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task UpdateStudent()
        {
            var studentId = 1;
            var student = new Student { Id = 1, Name = "Oscar Rojas" };
            var updatedStudent = new Student { Id = 1, Name = "Milton Rojas"};
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var mapperMock = new Mock<IMapper>();
            studentRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Student>()));
            var service = new StudentService(studentRepositoryMock.Object, mapperMock.Object);
            await service.UpdateAsync(new StudentDto { Id = updatedStudent.Id, Name = updatedStudent.Name });
            studentRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Student>(s =>
        s.Id == studentId &&
        s.Name == updatedStudent.Name 
    )), Times.Once);
        }

        [Test]
        public async Task DeleteStudent()
        {
            int studentId = 1; 
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var mapperMock = new Mock<IMapper>();
            var service = new StudentService(studentRepositoryMock.Object, mapperMock.Object);
            await service.DeleteAsync(studentId);
            studentRepositoryMock.Verify(repo => repo.DeleteAsync(studentId), Times.Once);
        }
        [Test]
        public async Task AddStudent_ShouldCallAddAsync_WhenStudentIsValid()
        {
            var newStudentDto = new StudentDto { Id = 1, Name = "John Doe"};
            var newStudent = new Student { Id = newStudentDto.Id, Name = newStudentDto.Name};
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var mapperMock = new Mock<IMapper>();
            var service = new StudentService(studentRepositoryMock.Object, mapperMock.Object);
            studentRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Student>()))
                                 .Returns(Task.CompletedTask) 
                                 .Verifiable(); 

            mapperMock.Setup(m => m.Map<Student>(newStudentDto))
                      .Returns(newStudent); 
            await service.AddAsync(newStudentDto);
            studentRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Student>(s =>
                s.Id == newStudentDto.Id &&
                s.Name == newStudentDto.Name
            )), Times.Once, "El método AddAsync no fue llamado correctamente.");
        }

    }
}
