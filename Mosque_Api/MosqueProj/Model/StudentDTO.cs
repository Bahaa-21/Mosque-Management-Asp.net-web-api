using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Model
{
    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; } 

        public GroupDTO Groups { get; set; }
    } 
    public class CreateStudentDTO
    {
        [Required, MaxLength(30)]

        public string First_Name { get; set; }
        [Required, MaxLength(30)]

        public string Last_Name { get; set; }
        [Required, MaxLength(25)]

        public string Father_Name { get; set; }

        public string Full_Name { get; set; }

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
