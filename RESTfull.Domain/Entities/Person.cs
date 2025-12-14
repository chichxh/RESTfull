using System.Collections.Generic;
using System.Data;

namespace RESTfull.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string PhoneAlt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
