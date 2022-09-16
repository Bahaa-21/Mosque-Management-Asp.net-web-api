using MosqueProj.Data;

namespace MosqueProj.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly MosqueDbContext _context;
    private IGenericRepository<Group> _groups;
    private IGenericRepository<Teacher> _teachers;
    private IGenericRepository<Student> _students;
    private IGenericRepository<Subject> _subjects;
    private IGenericRepository<Year> _years;


    public UnitOfWork(MosqueDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Year> Years => _years ??= new GenericRepository<Year>(_context);

    public IGenericRepository<Group> Groups => _groups ??= new GenericRepository<Group>(_context);

    public IGenericRepository<Teacher> Teachers => _teachers ??= new GenericRepository<Teacher>(_context);
    public IGenericRepository<Student> Students => _students ??= new GenericRepository<Student>(_context);

    public IGenericRepository<Subject> Subjects => _subjects ??= new GenericRepository<Subject>(_context);
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() =>
        await _context.SaveChangesAsync();
}
