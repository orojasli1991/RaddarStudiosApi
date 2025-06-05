using System;
using AutoMapper;
using StudentManagementInterRapidisimo.Application.Dto;
using StudentManagementInterRapidisimo.Domain.Entities;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}
