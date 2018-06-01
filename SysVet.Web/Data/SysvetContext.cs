using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using SysVet.Web.Models;

namespace SysVet.Web.Data
{
    public class SysvetContext : DbContext
    {
        public SysvetContext():base("Sysvet_Desenv") 
        {

        }

        public DbSet<Pet> Pet { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}