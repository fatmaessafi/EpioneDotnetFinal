using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    class AppointmentConfig : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfig()
        {   
           
            // Report One to One
            HasRequired<Report>(t => t.Report).WithRequiredPrincipal(t => t.Appointment);

               // One to Many Doctor and Appointment
                HasRequired<Doctor>(a => a.Doctor).WithMany(t => t.ListAppointment)
              .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);

            // One to Many Patient and Appointment
            HasRequired<Patient>(a => a.Patient).WithMany(t => t.ListAppointment)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);

            //Optional one to one with Step
            HasOptional<Step>(x => x.Step)
           .WithOptionalPrincipal()
           .Map(x => x.MapKey("AppointmentId"));

        }
                
    }
}
