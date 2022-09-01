using System;
using System.Collections.Generic;

namespace MosqueProj.Entities
{
    public class Year
    {
        public int Id { get; set; }
        public DateTime YearDate { get; set; }

        public virtual IList<Group> Groups { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}