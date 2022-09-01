using MosqueProj.Model;
using System.Threading.Tasks;

namespace MosqueProj.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoingUserDTO userDTO);
        Task<string> CreateToken();
    }
}
