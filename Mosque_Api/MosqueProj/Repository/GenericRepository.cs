using Microsoft.EntityFrameworkCore;
using MosqueProj.Data;
using System.Linq.Expressions;
using X.PagedList;

namespace MosqueProj.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MosqueDbContext _context;
    private readonly DbSet<T> _db;

    public GenericRepository(MosqueDbContext context)
    {
        _context = context;
        _db = _context.Set<T>();
    }


    public async Task Delete(int id)
    {
        var entitty = await _db.FindAsync(id);
        _db.Remove(entitty);
    }

    public void DeleteRange(IEnumerable<T> entities) => _db.RemoveRange(entities);
    

    public async Task<T> Get(Expression<Func<T, bool>> expression = null, string[] includes = null)
    {
        IQueryable<T> query = _db;
        if(includes != null)
        {
            foreach (var item in includes)
            {
                query= query.Include(item);
            }
        }
        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includes = null)
    {
        IQueryable<T> query = _db;

        if(expression != null)
        {
            query = query.Where(expression);
        }

        if (includes != null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }

        if(orderBy != null)
        {
            query = orderBy(query);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IPagedList<T>> GetAll(RequestParams requestParams = null, string[] includes = null)
    {
        IQueryable<T> query = _db;

        if (includes != null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber,requestParams.PageSize);
    }

    public async Task Insert(T entity) => await _db.AddAsync(entity);

    public async Task InsertRange(IEnumerable<T> entities) => await _db.AddRangeAsync(entities);

    public async Task<T> Select(Expression<Func<T, bool>> expression = null, Expression<Func<T, T>> selesction = null)
    {
        IQueryable<T> query = _db;
        if(expression != null)
        query = query.Select(selesction);

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public void Update(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
