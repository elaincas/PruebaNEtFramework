using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaCSharpProductos;
using PruebaCSharpProductos.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Data.Entity;
using System.Configuration;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ProductsDbContext context = new ProductsDbContext(PruebaCSharpProductos.Properties.Settings.Default.ConnectionBd);
            UnitOfWork unit = new UnitOfWork(context);
            Login frmLogin = new Login(unit);
            Application.Run(frmLogin);
        }


    }
}
