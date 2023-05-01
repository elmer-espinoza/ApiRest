using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestService.Models
{

    [Table (name: "ApiRestUser")]
    public class User
    {
        [Column(name: "Username")]
        public string Username { get; set; } //= "Elmer";
        public string Password { get; set; } //= "Pass123"; 
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rol { get; set; }
    }

}
