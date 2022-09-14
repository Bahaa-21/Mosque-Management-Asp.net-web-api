using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Father_Name { get; set; }
        public string PhoneNumber {get ; set;}
        public int CountPage { get; set; }
        public  int CountOfAbsenceDay { get; set; }
        public short Age { get; set; }
        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public virtual Group Groups { get; set; }
    }
}