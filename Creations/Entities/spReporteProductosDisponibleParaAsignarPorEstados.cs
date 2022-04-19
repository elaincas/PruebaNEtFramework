using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Creations.Entities
{
    public class spReporteProductosDisponibleParaAsignarPorEstados
    {

        public int Cantidad { get; set; }
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int EstadoID { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
    }
}
