using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Application.Dtos
{
    public class LoginDto
    {
        public string USuario { get; set; }
        public string Clave { get; set; }
        public int UsuarioId { get; set; }
        public bool EsDtoValido(out string mensaje)
        {
            mensaje = "Ok";
            if (String.IsNullOrEmpty(USuario))
            {
                mensaje = "Ingrese un usuario valido por favor";
                return false;
            }
            if (String.IsNullOrEmpty(Clave))
            {
                mensaje = "La clave no puede estar vacía";
                return false;
            }
            return true;
        }
    }
}
