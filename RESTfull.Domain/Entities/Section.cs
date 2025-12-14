using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTfull.Domain.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int DirectionId { get; set; }
        [ForeignKey(nameof(DirectionId))]
        public virtual Direction Direction { get; set; }

        public int? VenueId { get; set; }
        [ForeignKey(nameof(VenueId))]
        public virtual Venue Venue { get; set; }
    }
}
