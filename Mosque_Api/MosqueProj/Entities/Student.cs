using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string FatherName { get; set; }
        public string FullName { get; set; }
        [Range(10 , 20)]
        public short Age { get; set; }
        public string PhoneNumber { get; set; }
        public int Point { get; set; } = 0;
        public  int? AttendanceDays { get; set; }
        public int GroupId { get; set; }
        
        //Navigation Properties
        public virtual Group Groups { get; set; }
    }
}