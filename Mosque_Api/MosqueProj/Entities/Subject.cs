using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string NameSubject { get; set; }

        public virtual List<Teacher> Teachers { get; set; }
    }
}