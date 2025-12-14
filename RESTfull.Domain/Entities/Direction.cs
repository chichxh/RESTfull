using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RESTfull.Domain.Entities
{
    public class Direction
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int ConferenceId { get; set; }
        [ForeignKey(nameof(ConferenceId))]
        public virtual Conference Conference { get; set; }

        public int? VenueId { get; set; }
        [ForeignKey(nameof(VenueId))]
        public virtual Venue Venue { get; set; }

        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
