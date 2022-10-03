using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MosqueProj.Model
{

    public class LoingUserDTO
    {
        [Required, DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserDTO : LoingUserDTO
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required ,DataType(DataType.PhoneNumber)]
        public  string PhoneNumber { get; set; }
        
        public ICollection<string> Roles { get; set; }
    }

}
