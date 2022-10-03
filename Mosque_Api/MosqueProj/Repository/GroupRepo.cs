using Microsoft.EntityFrameworkCore;
using MosqueProj.Data;
using System.Linq.Expressions;

namespace MosqueProj.Repository
{
    public class GroupRepo : GenericRepository<Group>, IGroupRepo
    {
        private readonly MosqueDbContext _db;
        public GroupRepo(MosqueDbContext db) : base(db)
        {
        }

        public async Task<GroupTeachersDTO> GetGroupWithTeachers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
