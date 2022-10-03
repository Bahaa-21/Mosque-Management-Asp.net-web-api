using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Model
{
    public class SubjectDTO : CreateSubjectDTO
    {
        public int Id { get; set; }

        public List<TeacherDTO> Teachers { get; set; }            

    }
    public class CreateSubjectDTO
    {
        [Required, MaxLength(30)]
        public string Name_Subject { get; set; }

    }

}
