using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name_Subject { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}