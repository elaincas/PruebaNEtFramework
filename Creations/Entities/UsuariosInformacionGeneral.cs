using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure.Entities
{
    public class UsuariosInformacionGeneral
    {
        [Key]
        public int Id { get; set; }
        public int Perfil_Id { get; set; }
        public string Usuario { get; set; }
        public byte[] Clave { get; set; }
        public int AplicacionId { get; set; }
        public bool Activo { get; set; }
    }

}
