namespace MosqueProj.Model
{
    public class TeacherDTO 
    {
        public int Id { get; set; }
        [Display(Name ="Your Full Name")]
        public string FullName { get; set; }
        [Display(Name ="Subject Name")]
        public CreateSubjectDTO Subjects {get ; set;}
    }

    public class CreateTeacherDTO
    {

        [Required, MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, MinLength(8), MaxLength(16)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int? AttendanceDays { get; set; }
        [Required]
        public short Age { get; set; }
        [Required]
        public int SubjectId { get; set; }

    }

    public class UpdateTeacherDTO
    {
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public short Age { get; set; }
        public int SubjectId { get; set; }
    }
    public class TeacherGroupsDTO
    {
        public List<GroupTeachersDTO> GroupTeachers { get; set; }
    }
}
