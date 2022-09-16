using System.Linq.Expressions;
using X.PagedList;

namespace MosqueProj.IReprository;

public interface IGenericRepository<T>  where T : class
{
    Task<IList<T>> GetAll(Expression<Func<T , bool>> expression = null,
        Func<IQueryable<T> , IOrderedQueryable<T>> orderBy = null,
        string[] includes = null);

    Task<IPagedList<T>> GetAll (RequestParams requestParams = null , string[] includes = null);

    Task<T> Get(Expression<Func<T, bool>> expression = null,
       string[] includes = null);
       
    Task Insert(T entity);

    Task InsertRange(IEnumerable<T> entities);

    Task Delete(int id);

    void Update(T entity);

    void DeleteRange(IEnumerable<T> entities);

}
