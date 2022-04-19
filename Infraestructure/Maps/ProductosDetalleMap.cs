using PruebaCSharpProductos.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure.Maps
{
    public class ProductosDetalleMap: EntityTypeConfiguration<ProductosDetalle>
    {
        public ProductosDetalleMap()
        {
            this.ToTable("ProductosDetalles");
            this.HasKey(c => c.ProductoDetalleID);
            this.Property(c => c.ProductoDetalleID);
            this.Property(c => c.Precio).HasColumnType("money");
            this.Property(c => c.ProductoId);
            this.Property(c => c.ZONAID).IsOptional();
            this.Property(c => c.Observacion);
            this.Property(c => c.FechaIngreso).HasColumnType("datetime");
            this.Property(c => c.EstadoID);
            this.Property(c => c.Activo).HasColumnType("bit");
            this.HasRequired(x => x.Productos)
       .WithMany(x => x.ProductosDetalles)
       .HasForeignKey(x => x.ProductoId);

        }

    }
}
