namespace MosqueProj.Configurations;

public class MapperInitilizer : Profile
{
    public MapperInitilizer()
    {
        CreateMap<Year , YearDTO>().ReverseMap();
        CreateMap<Year , CreateYearDTO>().ReverseMap();

        CreateMap<Group , GroupDTO>().ReverseMap();
        CreateMap<Group , CreateGroupDTOS>().ReverseMap();
        CreateMap<Group , UpdateGroupDTOS>().ReverseMap();
        CreateMap<Group_Teacher , GroupTeachersDTO>().ReverseMap();


        CreateMap<Teacher , TeacherDTO>().ReverseMap();
        CreateMap<Teacher , CreateTeacherDTO>().ReverseMap();

        CreateMap<Student , StudentDTO>().ReverseMap();
        CreateMap<Student, CreateStudentDTO>().ReverseMap();

        CreateMap<Subject, SubjectDTO>().ReverseMap();
        CreateMap<Subject, CreateSubjectDTO>().ReverseMap();

        CreateMap<Users ,UserDTO>().ReverseMap();
        CreateMap<Users,LoingUserDTO>().ReverseMap();

    }
}
