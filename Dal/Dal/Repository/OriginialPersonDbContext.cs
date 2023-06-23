using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPOC.Repository.Models;
using WaterPOC.Repository;

namespace Dal.Repository
{
    public class OriginalPersonDbContext: DbContext
    {
        
    public OriginalPersonDbContext()
        {
        }

        public OriginalPersonDbContext(DbContextOptions<OriginalPersonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WaterLog> WaterLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=MAGSNL22\\SQLEXPRESS;Initial Catalog=PersonDatabase;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);
        }

    }
}

