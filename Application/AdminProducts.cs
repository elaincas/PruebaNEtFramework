using PruebaCSharpProductos.Application.Dtos;
using PruebaCSharpProductos.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaCSharpProductos.Application
{
    public partial class AdminProducts : Form
    {
        private readonly CommonService _commonService;
        public AdminProducts(CommonService commonService)
        {
            InitializeComponent();
            _commonService = commonService;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoDto productoDto = new ProductoDto() {
                NombreProducto = txtProductName.Text,
                Observaciones = txtObservacion.Text,
                Precio = nboxPrecio.Value,
                
            };
            string Mensaje = string.Empty;
            if (!productoDto.EsDtoValido(out Mensaje))
            {
                MessageBox.Show(Mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

            var respuesta = _commonService.GuardarProducto(productoDto);

            if (respuesta.MensajeRespuesta != "Ok")
            {
                MessageBox.Show(respuesta.MensajeRespuesta, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }
    }
}
