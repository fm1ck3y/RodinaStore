using RodinaStore.Model;
using System;
using System.Data.Entity;

namespace RodinaStore.DateBase
{
    public class RodinaStoreContext : DbContext
    {

        public RodinaStoreContext() : base(GetRemoteConnectionString())
        {

        }

        public static string GetRemoteConnectionString()
        {
            return "MainConnection.RodinaStore";
        }

        public static bool CheckConnection(string connectionString)
        {
            try
            {
                using (DbContext dbContext = new DbContext(connectionString))
                    dbContext.Database.Exists();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<BaseObject> BaseObjects { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Firm> Firms { get; set; }

        public virtual DbSet<SoldItem> SoldItems { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Permission> SettingsClient { get; set; }

        public virtual DbSet<AuditItem> AuditItems { get; set; }
    }
}

