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

     public DbSet<Serie> TablaSerie { get; set; }
     public DbSet<Comprobante> TablaComprobante { get; set; }
     public DbSet<Producto> TablaProducto { get; set; }
     public DbSet<Cliente> TablaCliente { get; set; }

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
