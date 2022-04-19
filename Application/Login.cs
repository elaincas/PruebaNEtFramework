using PruebaCSharpProductos.Application.Dtos;
using PruebaCSharpProductos.Infraestructure;
using PruebaCSharpProductos.Infraestructure.Entities;
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
    public partial class Login : Form
    {
        private readonly CommonService _commonService;
        public Login(IUnitOfWork unit)
        {
            InitializeComponent();
            _commonService = new CommonService(unit);
            _commonService.frmLogin = this;
            
        }

     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            try
            {

                var mensaje = string.Empty;
                LoginDto login = new LoginDto()
                {
                    USuario = txtUsuario.Text,
                    Clave = txtPassword.Text
                };


                if (!login.EsDtoValido(out mensaje))
                {
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!_commonService.UsuarioValido(login))
                {
                    MessageBox.Show("El usuario no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _commonService.login = login;

                Menu menu = new Menu(login.USuario,_commonService);
                menu.Show();
                this.Hide();
                LimpiarForm();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LimpiarForm()
        {
            txtPassword.Text = String.Empty;
            txtUsuario.Text = String.Empty;
        }
    }
}
