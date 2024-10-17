using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Entities
{
    public class BlogDBContext:DbContext
    {
        public BlogDBContext(): base("BlogDBConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDBContext, Migrations.Configuration>("BlogDBConnection") );
        }
        public DbSet<Admin> Adminler { get; set; }

        public DbSet<Blog> Bloglar { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}