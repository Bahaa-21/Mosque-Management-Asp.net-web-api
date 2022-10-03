namespace MosqueProj.IReprository;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Year> Years { get; }
    IGroupRepo Groups { get; }
    IGenericRepository<Group_Teacher> GroupsTeachers { get; }
    IGenericRepository<Teacher> Teachers { get; }
    IGenericRepository<Student> Students { get; }
    IGenericRepository<Subject> Subjects { get; }

    Task Save();
}
