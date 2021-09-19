using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrabajadoresPrueba.Entidades;

namespace TrabajadoresPrueba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Trabajadores>().ToTable("Trabajadores", "DBO");
            builder.Entity<Departamento>().ToTable("Departamento", "DBO");
            builder.Entity<Provincia>().ToTable("Provincia", "DBO");
            builder.Entity<Distrito>().ToTable("Distrito", "DBO");
            builder.Entity<PR_TRABA>().ToTable("PR_TRABA", "DBO");
        }

        public DbSet<Trabajadores> Trabajadores { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<PR_TRABA> PR_TRABA { get; set; }
    }
}