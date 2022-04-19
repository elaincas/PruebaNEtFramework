using PruebaCSharpProductos.Creations.Entities;
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
    public partial class FrmPrintReportProductos : Form
    {
        public FrmPrintReportProductos()
        {
            InitializeComponent();
        }
        public void SetearDataReport(List<spReporteProductosDisponibleParaAsignarPorEstados> listado,string nombreEmpresa)
        {
            rptAvalaibleProducts1.SetDataSource(listado);
            rptAvalaibleProducts1.SetParameterValue("nombreEmpresa", nombreEmpresa);
            crystalReportViewer.ReportSource = rptAvalaibleProducts1;
            crystalReportViewer.Refresh();
        }
    }
}
