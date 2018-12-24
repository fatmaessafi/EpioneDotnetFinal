using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class AnalyticsConfig : EntityTypeConfiguration<Analytics>
    {
        public AnalyticsConfig()
        {   // One to Many Doctor and Analytics
            HasRequired<Doctor>(a => a.DoctorAnalytics).WithMany(t => t.ListAnalytics)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);
        }
    }
}
