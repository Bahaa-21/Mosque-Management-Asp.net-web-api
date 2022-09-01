using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string NameGroup { get; set; }
        public short Min_Old { get; set; }
        public short Max_Old { get; set; }

        public int? YearId { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teachers { get; set; }

        public virtual IList<Student> Students { get; set; }

    }
}