namespace SqlBackendEf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyMachineModel : DbContext
    {
        public MyMachineModel()
            : base("data source=localhost\\SQLEXPRESS;initial catalog=Muenchen201810;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
           

        {
        }

        public virtual DbSet<Maschine> Maschine { get; set; }
        public virtual DbSet<Temperatur> Temperatur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    public partial class MyTemperaturModel : DbContext
    {
        public MyTemperaturModel()
            : base("data source=localhost\\SQLEXPRESS;initial catalog=Muenchen201810;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        
        public virtual DbSet<Temperatur> Temperatur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
