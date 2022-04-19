using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure.Entities
{
    public class ProductosDetalle
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductoDetalleID { get; set; }
        public int ProductoId { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        public int EstadoID { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int UsuarioIngresa { get; set; }
        public string Observacion { get; set; }
        public bool Activo { get; set; }
        public int ZONAID { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
