using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Application.Dtos
{
    public class RespuestaData<TEntity> where TEntity : class
    {
       
        public TEntity Data { get; set; }

        public string MensajeRespuesta { get; set; }

    }
}
