using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext : DbContext
{
    public DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=estudiantes.db");
    }
}