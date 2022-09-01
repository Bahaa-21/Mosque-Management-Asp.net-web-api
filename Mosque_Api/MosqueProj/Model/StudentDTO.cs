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
    
        public string First_Name { get; set; }
        [Required, MaxLength(50)]

        public string Last_Name { get; set; }
        [Required, MaxLength(50)]

        public string Father_Name { get; set; }

        public string Full_Name { get; set; }
        public int CountPage { get; set; }
        public  int CountOfAbsenceDay { get; set; }
        [Required]
        public byte Age { get; set; }

        public int GroupId { get; set; }
    }
}
