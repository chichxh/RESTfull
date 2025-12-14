using RESTfull.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RESTfull.Domain.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public string Index { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int? VenueId { get; set; }
        [ForeignKey(nameof(VenueId))]
        [JsonIgnore]
        public virtual Venue? Venue { get; set; }

        [JsonIgnore]
        public virtual ICollection<Direction> Directions { get; set; } = new List<Direction>();
    }
}
