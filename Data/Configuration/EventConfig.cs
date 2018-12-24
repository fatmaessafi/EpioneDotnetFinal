using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class EventConfig : EntityTypeConfiguration<Event>
    {
        public EventConfig() 
        {
            HasRequired<Doctor>(t => t.DoctorEvent).WithMany(t => t.ListEvent)
               .HasForeignKey(t => t.DoctorId)
               .WillCascadeOnDelete(true);
        }
    }
}
