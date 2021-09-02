using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    //[Table("User", Schema = "Customers")]
    public class AppUser
    {
        public int Id { get; set; }
        //[Column(TypeName = "VARCHAR(128)")]
        public string UserName { get; set; }
        //[Column(TypeName = "VARCHAR(30)")]
        public string FirstName { get; set; }
        //[Column(TypeName = "VARCHAR(40)")]
        public string LastName { get; set; }
        //[Column(TypeName = "VARCHAR(50)")]
        public string City { get; set; }
        //[Column(TypeName = "VARCHAR(50)")]
        public string Country { get; set; }
        //[Column(TypeName = "VARCHAR(128)")]
        public string Email { get; set; }
        //[Column(TypeName = "VARCHAR(15)")]
        public string Phone { get; set; }
    }
}