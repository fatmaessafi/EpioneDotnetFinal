using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    internal class StepConfig : EntityTypeConfiguration<Step>
    {
        public StepConfig()

        {
            //Optional one to one with Appointment
            HasOptional<Appointment>(x => x.Appointment)
           .WithOptionalPrincipal()
           .Map(x => x.MapKey("StepId"));

            // One to Many Treatment et Step
            HasRequired<Treatment>(a => a.Treatment).WithMany(t => t.ListSteps)
         .HasForeignKey(e => e.TreatmentId).WillCascadeOnDelete(true);
        }
    }
}