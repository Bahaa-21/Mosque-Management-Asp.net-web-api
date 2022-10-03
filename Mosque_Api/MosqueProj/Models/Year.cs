namespace MosqueProj.Entities
{
    public class Year
    {
        public int Id { get; set; }
        public DateTime StartCourse { get; set; }
        public DateTime EndCourse { get; set; }

        //Navigations Properties
        public virtual List<Group> Groups { get; set; }
    }
}