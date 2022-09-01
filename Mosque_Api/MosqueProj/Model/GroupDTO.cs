using MosqueProj.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Model
{
    public class CreateGroupDTOS
    {
        [Required]
        [StringLength(100)]
        public string NameGroup { get; set; }
        [Required]
        [MinLength(10)]
        public short Min_Old { get; set; }
        [Required]
        [MinLength(25)]
        public short Max_Old { get; set; }
        public int? YearId { get; set; }
        public int TeacherId { get; set; }
    }

    public class UpdateGroupDTOS : CreateGroupDTOS {}


    public class GroupDTO : CreateGroupDTOS
    {
        [Required]
        public int Id { get; set; }
        public IList<StudentDTO> Students { get; set; }
        public TeacherDTO Teachers { get; set; }
    }
}
