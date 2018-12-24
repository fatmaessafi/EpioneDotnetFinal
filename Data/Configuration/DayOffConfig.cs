using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    internal class DayOffConfig : EntityTypeConfiguration<DayOff>
    {
        public DayOffConfig()
        {
            // One to Many Doctor and DayOff
            HasRequired<Doctor>(a => a.DoctorDayOff).WithMany(t => t.ListDayOff)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);
        }
    }
}