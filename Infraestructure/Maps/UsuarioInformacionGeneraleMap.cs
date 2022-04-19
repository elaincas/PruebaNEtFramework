using PruebaCSharpProductos.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure.Maps
{
    public class UsuarioInformacionGeneraleMap: EntityTypeConfiguration<UsuariosInformacionGeneral>
    {
        public UsuarioInformacionGeneraleMap()
        {
            this.ToTable("UsuarioInformacionGeneral");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id);
            this.Property(x => x.Activo).HasColumnType("bit");
            this.Property(x => x.AplicacionId);
            this.Property(x => x.Clave).HasColumnType("varbinary");
            this.Property(x => x.Perfil_Id);
            this.Property(x => x.Usuario);
        }

    }
}
