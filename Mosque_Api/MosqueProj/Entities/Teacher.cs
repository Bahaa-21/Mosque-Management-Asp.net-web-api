using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueProj.Entities
{
    public class Teacher
    {
            public int Id { get; set; }
           
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
            public int? CountOfAbsenceDay { get; set; }

            #region Relations
            public virtual Group Groups { get; set; }
            public int SubjectId { get; set; }
            [ForeignKey("SubjectId")]
            public Subject Subjects { get; set; }

            public ICollection<Year> Years { get; set; }
        #endregion

    }
}