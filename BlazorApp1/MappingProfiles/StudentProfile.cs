using AutoMapper;

namespace BlazorApp1.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Entities.Student, Models.StudentViewModel>()
                .ReverseMap();
        }
    }
}
