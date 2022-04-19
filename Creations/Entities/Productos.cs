using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure.Entities
{
    public class Productos
    {
        [Key,DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual List<ProductosDetalle> ProductosDetalles { get; set; }
    }
}
