using Data.Conventions;
using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Contexte :IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public static Contexte Create()
        {
            return new Contexte();
        }
        static Contexte()
        {
            Database.SetInitializer<Contexte>(null);
        }

        public Contexte() : base("name=EpioneDB")
        {
                
            }
        //DbSets
        public DbSet<Analytics> Analytics { set; get; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<DayOff> DayOff { set; get; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Step> Step { set; get; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<VisitReason> VisitReason { set; get; }
        public DbSet<StepRequest> StepRequest { set; get; }
        public DbSet<Event> Event { set; get; }


        //On ModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            //Fluent API Configurations
            modelBuilder.Configurations.Add(new Configuration.AnalyticsConfig());
            modelBuilder.Configurations.Add(new Configuration.AppointmentConfig());
            modelBuilder.Configurations.Add(new Configuration.DayOffConfig());
            modelBuilder.Configurations.Add(new Configuration.DoctorConfig());
            modelBuilder.Configurations.Add(new Configuration.MessageConfig());
            modelBuilder.Configurations.Add(new Configuration.StepConfig());
            modelBuilder.Configurations.Add(new Configuration.VisitReasonConfig());
            modelBuilder.Configurations.Add(new Configuration.TreatmentConfig());
            modelBuilder.Configurations.Add(new Configuration.EventConfig());


            //Add Convention

            modelBuilder.Conventions.Add(new DateTimeConvention());

        }
    }
   
}

