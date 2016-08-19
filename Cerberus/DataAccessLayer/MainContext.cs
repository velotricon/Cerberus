namespace Cerberus.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class MainContext : DbContext
    {
        public MainContext()
            : base("name=MainContext")
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Privilage> Privilages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RolePrivilages> RolePrivilages { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
