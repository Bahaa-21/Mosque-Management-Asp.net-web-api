using MosqueProj.Data;

namespace MosqueProj.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly MosqueDbContext _context;
    private IGroupRepo _groups;
    private IGenericRepository<Teacher> _teachers;
    private IGenericRepository<Student> _students;
    private IGenericRepository<Subject> _subjects;
    private IGenericRepository<Year> _years;
    private IGenericRepository<Group_Teacher> _groupTeachers;
    private IGenericRepository<Users> _user;


    public UnitOfWork(MosqueDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Year> Years => _years ??= new GenericRepository<Year>(_context);

    public IGroupRepo Groups => _groups ??= new GroupRepo(_context);
    public IGenericRepository<Group_Teacher> GroupsTeachers => _groupTeachers??= new GenericRepository<Group_Teacher>(_context);

    public IGenericRepository<Teacher> Teachers => _teachers ??= new GenericRepository<Teacher>(_context);
    public IGenericRepository<Student> Students => _students ??= new GenericRepository<Student>(_context);

    public IGenericRepository<Subject> Subjects => _subjects ??= new GenericRepository<Subject>(_context);
    public IGenericRepository<Users> Users => _user ??= new GenericRepository<Users>(_context);
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() => await _context.SaveChangesAsync();
}
