using System.Collections.Generic;

namespace RESTfull.Domain.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MapUrl { get; set; }

        public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();
        public virtual ICollection<Direction> Directions { get; set; } = new List<Direction>();
        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
