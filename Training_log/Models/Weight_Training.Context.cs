//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Training_log.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Weight_TrainingDBEntitiesCTX : DbContext
    {
        public Weight_TrainingDBEntitiesCTX()
            : base("name=Weight_TrainingDBEntitiesCTX")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bench> Benches { get; set; }
        public virtual DbSet<Bodyweight> Bodyweights { get; set; }
        public virtual DbSet<Deadlift> Deadlifts { get; set; }
        public virtual DbSet<Squat> Squats { get; set; }
    }
}
