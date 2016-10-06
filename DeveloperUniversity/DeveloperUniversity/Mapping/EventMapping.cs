using System.Data.Entity.ModelConfiguration;
using DeveloperUniversity.Models;

namespace DeveloperUniversity.Mapping
{
    public class EventMapping : EntityTypeConfiguration<Event>
    {
        public EventMapping()
        {
            HasKey(p => p.EventId);

            Property(p => p.Description).IsRequired();
            Property(p => p.EventStartDate).IsOptional();
            Property(p => p.EventEndDate).IsRequired();
            Property(p => p.EventName).IsRequired();
            Property(p => p.EventType).IsRequired();
            Property(p => p.EventTime).IsRequired();

            Property(p => p.AttendenceCost).IsOptional();
        }

    }
}