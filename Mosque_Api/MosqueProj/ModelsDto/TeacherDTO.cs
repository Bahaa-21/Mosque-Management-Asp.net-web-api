namespace MosqueProj.Model
{
    public class TeacherDTO : CreateTeacherDTO
    {
        public int Id { get; set; }

        public SubjectDTO Subject {get ; set;}
    }

    public class CreateTeacherDTO
    {
        
        [Required, MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(30)]

        public string LastName { get; set; }
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(16)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? AttendanceDays { get; set; }
        public short Age { get; set; }
        [Required]
        public int SubjectId { get; set; }

    }

    public class TeacherGroupsDTO
    {
        public List<GroupTeachersDTO> GroupTeachers { get; set; }
    }
}
