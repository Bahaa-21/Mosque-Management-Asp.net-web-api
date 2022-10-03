namespace MosqueProj.Model
{
    public class CreateGroupDTOS
    {
        public int Id { get; set; }
        [Required]

        public string NameGroup { get; set; }
        [Required]

        public short Min_Old { get; set; }
        [Required]

        public short Max_Old { get; set; }

        public int YearId { get; set; }
    }

    public class UpdateGroupDTOS : CreateGroupDTOS {}


    public class GroupDTO : CreateGroupDTOS
    {
        public  List<StudentDTO> Students { get; set; }
        public List<GroupTeachersDTO> Groups_Teachers { get; set; }
    }


    public class GroupTeachersDTO
    {
        public int GroupId { get; set; }
        public GroupDTO Groups { get; set; }
        public int TeacherId { get; set; }
        public TeacherDTO Teachers { get; set; }

    }
}
