using Epam.HostFiles.Core.Configuration;
using Epam.HostFiles.Model.Models;
using System.Data.Entity;

namespace Epam.HostFiles.Core
{
    public class HostFilesEntities : DbContext
    {
        static HostFilesEntities()
        {
            System.Data.Entity.Database.SetInitializer(new HostFilesSeedData());
        }

        public HostFilesEntities() : base("HostFilesEntities") { }
        public HostFilesEntities(string connectionString) : base(connectionString) { }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
        }
    }
}
