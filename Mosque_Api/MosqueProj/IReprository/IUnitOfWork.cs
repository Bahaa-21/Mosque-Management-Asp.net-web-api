using MosqueProj.Entities;
using System;
using System.Threading.Tasks;

namespace MosqueProj.IReprository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Year> Years { get; }
        IGenericRepository<Group> Groups { get; }
        IGenericRepository<Teacher> Teachers { get; }
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Subject> Subjects { get; }

        Task Save();
    }
}
