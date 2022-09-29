namespace MosqueProj.Entities
{
    public class Group
    {
        public int Id { get; set; }
        [Required]

        public string NameGroup { get; set; }
        [Required]

        public short Min_Old { get; set; }
        [Required]

        public short Max_Old { get; set; }

        public int YearId { get; set; }
        public int TeacherId { get; set; }


        //Navigations Properties
        public virtual Year Years { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Group_Teacher> Groups_Teachers { get; set; }

    }
}