using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class TreatmentConfig : EntityTypeConfiguration<Treatment>
    {
        public TreatmentConfig()
        {

           

            // One to Many Doctor and Treatment
            HasRequired<Doctor>(a => a.ReferringDoctor).WithMany(t => t.ListReferringTreatment)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);

            // One to Many Patient and Treatment
            HasRequired<Patient>(a => a.Patient).WithMany(t => t.ListTreatment)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);


        }

    }
}
