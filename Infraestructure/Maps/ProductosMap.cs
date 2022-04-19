using PruebaCSharpProductos.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure.Maps
{
    public class ProductosMap : EntityTypeConfiguration<Productos>
    {
        public ProductosMap()
        {
            this.ToTable("Productos");
            this.HasKey(c=>c.Id);
            this.Property(c => c.Id).HasColumnName("ProductoID");
            this.Property(c => c.Activo).HasColumnType("bit");
            this.Property(c => c.Descripcion);
           this.HasRequired(x => x.ProductosDetalles).WithRequiredPrincipal();
        }
    }
}
