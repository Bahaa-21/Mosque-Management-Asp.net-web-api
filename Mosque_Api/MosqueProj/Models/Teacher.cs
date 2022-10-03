using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public short Age { get; set; }
        [Required]
        public int? AttendanceDays { get; set; }
        public int SubjectId { get; set; }


        //Navigations Properties
        public virtual Subject Subjects { get; set; }

        public virtual List<Group_Teacher> Groups_Teachers { get; set; }
    }
}