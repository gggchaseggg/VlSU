using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class EntityDBContext : DbContext
    {
        public virtual DbSet<News> News { get; set; } = null;
        public virtual DbSet<Categ> Categories { get; set; } = null;

        public EntityDBContext()
        {
            Database.EnsureCreated();
        }

        public EntityDBContext(DbContextOptions<EntityDBContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("host=localhost;port=3306;database=newslist;username=root;password=daniil;");
            }
        }
    }
}