using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class VisitReasonConfig : EntityTypeConfiguration<VisitReason>
    {
        public VisitReasonConfig()
        {   // One to Many Dotor et VisitReason
            HasRequired<Doctor>(t => t.DoctorVisitReason).WithMany(t => t.ListVisitReason)
               .HasForeignKey(t => t.DoctorId)
               .WillCascadeOnDelete(true);
        }

    }
}
