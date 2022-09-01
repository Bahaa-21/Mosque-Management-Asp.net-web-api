using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Model
{
    public class TeacherDTO : CreateTeacherDTO
    {
        public int Id { get; set; }
        public GroupDTO Groups { get; set; }
    }

    public class CreateTeacherDTO
    {
        
        [Required, MaxLength(30)]
        public string First_Name { get; set; }
        [Required, MaxLength(30)]

        public string Last_Name { get; set; }
        [Required]

        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(16)]
        public string Password { get; set; }
        public byte Phone { get; set; }
        public int? CountOfAbsenceDay { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int SubjectId { get; set; }

    }
}
