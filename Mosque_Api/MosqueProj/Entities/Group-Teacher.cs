namespace MosqueProj.Entities
{
    public class Group_Teacher
    {
        public int GroupId { get; set; }
        public Group Groups { get; set; }


        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
    }
}
