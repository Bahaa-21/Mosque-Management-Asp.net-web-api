using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Student 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        [Range(10 , 20)]
        public short Age { get; set; }
        public int Point { get; set; } = 0;
        public  int? AttendanceDays { get; set; }
        public int GroupId { get; set; }
        
        //Navigation Properties
        public virtual Group Groups { get; set; }
    }
}