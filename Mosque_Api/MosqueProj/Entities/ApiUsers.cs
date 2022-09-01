using Microsoft.AspNetCore.Identity;

namespace MosqueProj.Entities
{
    public class ApiUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
