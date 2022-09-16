namespace MosqueProj.Services;

public interface IAuthManager
{
    Task<bool> ValidateUser(LoingUserDTO userDTO);
    Task<string> CreateToken();
}
