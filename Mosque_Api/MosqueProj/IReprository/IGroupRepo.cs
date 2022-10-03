using System.Linq.Expressions;

namespace MosqueProj.IReprository
{
    public interface IGroupRepo : IGenericRepository<Group>
    {
        Task<GroupTeachersDTO> GetGroupWithTeachers(int id);
    }
}
