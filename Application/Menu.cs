using PruebaCSharpProductos.Application;
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

namespace PruebaCSharpProductos
{
    public partial class Menu : Form
    {
        private readonly CommonService _commonService;
        public Menu(string userName, CommonService commonService)
        {
            InitializeComponent();
            lblUser.Text = userName;
            _commonService = commonService;
        }

        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoProductos frm = new ListadoProductos(_commonService);
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            _commonService.frmLogin.Show();
            _commonService.login = new Application.Dtos.LoginDto();
               
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminProducts form = new AdminProducts(_commonService);
            form.ShowDialog();
        }
    }
}
