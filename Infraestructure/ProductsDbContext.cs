using PruebaCSharpProductos.Application.Dtos;
using PruebaCSharpProductos.Infraestructure.Entities;
using PruebaCSharpProductos.Infraestructure.Maps;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace PruebaCSharpProductos.Infraestructure
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(string cadena) : base(cadena)
        {

            DbConnection connection = new SqlConnection(PruebaCSharpProductos.Properties.Settings.Default.ConnectionBd);

            new DbContext(connection, true);

        }

      

        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosDetalle> ProductosDetalle { get; set; }
        public DbSet<UsuariosInformacionGeneral> UsuariosInformacionGeneral { get; set; }
        public DbSet<ProductosDisponibleDto> ProductosDisponibleDto { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductosDetalleMap());
            modelBuilder.Configurations.Add(new ProductosMap());
            modelBuilder.Configurations.Add(new UsuarioInformacionGeneraleMap());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
