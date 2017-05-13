using OAuth.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Repository.Context
{
    internal class OAuthContext : DbContext
    {
        public OAuthContext() : base("OAuthContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ExternalUserLogin> ExternalUserLogins { get; set; }
    }
}
