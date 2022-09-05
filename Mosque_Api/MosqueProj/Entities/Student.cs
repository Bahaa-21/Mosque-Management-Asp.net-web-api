using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required , MaxLength(50)]
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
        [ForeignKey(nameof(GroupId))]
        public Group Groups { get; set; }
    }
}