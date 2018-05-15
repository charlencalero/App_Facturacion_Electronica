using AppEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMovilFE.Services
{
    class DatabaseContext: DbContext
    {

     public DbSet<Serie> TodoItems { get; set; }

    public DatabaseContext()
    {
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = DependencyService.Get<IDatabaseService>().GetDatabasePath();
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }
    }

  
}
