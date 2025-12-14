using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace RESTfull.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleType { get; set; } = string.Empty;

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person? Person { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AreaType AreaType { get; set; }
        public string AreaIndex { get; set; } = string.Empty;

        public void Validate()
        {
            if (PersonId <= 0) throw new InvalidOperationException("PersonId must be set.");
            if (AreaType == AreaType.Unknown) throw new InvalidOperationException("AreaType must be specified.");
            if (string.IsNullOrWhiteSpace(AreaIndex)) throw new InvalidOperationException("AreaIndex must be specified.");
        }
    }
}
