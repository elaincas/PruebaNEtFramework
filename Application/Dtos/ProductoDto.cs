using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Application.Dtos
{
    public class ProductoDto
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public string Observaciones { get; set; }

        public bool EsDtoValido(out string Mensaje)
        {
            Mensaje = "Ok";
            if (string.IsNullOrEmpty(NombreProducto))
            {
                Mensaje = "Ingrese un nombre de producto";
                return false;
            }

            if (string.IsNullOrEmpty(Observaciones))
            {
                Mensaje = "Ingrese una observación ";
                return false;
            }
            if (Precio <= 0)
            {
                Mensaje = "El precio no puede ser menor de 1";
                return false;
            }
            return true;
        }
    }
}
