using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace RESTfull.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleType { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public AreaType AreaType { get; set; }
        public string AreaIndex { get; set; }

        public void Validate()
        {
            if (PersonId <= 0) throw new InvalidOperationException("PersonId must be set.");
            if (AreaType == AreaType.Unknown) throw new InvalidOperationException("AreaType must be specified.");
            if (string.IsNullOrWhiteSpace(AreaIndex)) throw new InvalidOperationException("AreaIndex must be specified.");
        }
    }
}
