using System.Collections.Generic;
using System.Data;

namespace RESTfull.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string Phone { get; set; }
        public string PhoneAlt { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
