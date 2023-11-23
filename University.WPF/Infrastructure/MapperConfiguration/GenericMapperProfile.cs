using AutoMapper;
using University.DAL.Models;
using University.WPF.Models;

namespace University.WPF.Infrastructure.MapperConfiguration
{
    internal class GenericMapperProfile : Profile
    {
        public GenericMapperProfile() 
        { 
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Teacher, TeacherModel>().ReverseMap();
        }
    }
}
