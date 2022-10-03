using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Model
{
    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; } 
    } 
    public class CreateStudentDTO
    {
        [Required, MaxLength(30)]

        public string FirstName { get; set; }
        [Required, MaxLength(30)]

        public string LastName { get; set; }
        [Required, MaxLength(25)]

        public string FatherName { get; set; }

        public string FullName { get; set; }

        public  string PhoneNumber {get; set;}
        [Required]
        [MaxLength(25)]
        public short Age { get; set; }

        public int GroupId { get; set; }
    }

    public class UpdateStudentDTO : CreateGroupDTOS
    {
        public int? CountPage { get; set; }
        public  int? CountOfAbsenceDay { get; set; }

    }
}
