using PruebaCSharpProductos.Creations.Entities;
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
    public partial class ListadoProductos : Form
    {
        private readonly CommonService commonService;
        private List<spReporteProductosDisponibleParaAsignarPorEstados> dataListado; 

        public ListadoProductos(CommonService _commonService)
        {
            InitializeComponent();
            commonService = _commonService;
            dtFechaDesde.Format = DateTimePickerFormat.Custom;
            dtFechaDesde.CustomFormat = "dd-MM-yyyy";
            dtFechaHasta.Format = DateTimePickerFormat.Custom;
            dtFechaHasta.CustomFormat = "dd-MM-yyyy";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataListado = new List<spReporteProductosDisponibleParaAsignarPorEstados>();
            dataListado = commonService.ObtenerProductos() .Data ;
            dtListado.DataSource = null;
            dtListado.DataSource = dataListado;
            dtListado.Refresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmPrintReportProductos frm = new FrmPrintReportProductos();
            frm.SetearDataReport(dataListado,this.Name.ToString());
            frm.Show();
        }
    }
}
