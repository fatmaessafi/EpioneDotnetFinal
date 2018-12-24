using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class MessageConfig : EntityTypeConfiguration<Message>
    {
         public MessageConfig()
        {
            // One to Many Doctor and Message
            HasRequired<Doctor>(a => a.Doctor).WithMany(t => t.ListMsg)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);

            // One to Many Patient and Appointment
            HasRequired<Patient>(a => a.Patient).WithMany(t => t.ListMsg)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);
        }
   
}
 }
    

