using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WaterPOC.Repository.Models;

namespace WaterPOC.Repository;

public partial class WaterDbContext : DbContext
{
    public WaterDbContext()
    {
    }

    public WaterDbContext(DbContextOptions<WaterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<WaterLog> WaterLog { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=chn-sqldev2012;Initial Catalog=EnvHealthDev;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
