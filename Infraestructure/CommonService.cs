using PruebaCSharpProductos.Application.Dtos;
using PruebaCSharpProductos.Creations.Entities;
using PruebaCSharpProductos.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure
{
    public class CommonService
    {
        public Login frmLogin { get; set; }
        private readonly IUnitOfWork unitOfWork;
        public LoginDto login;
        public CommonService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            login = new LoginDto();
        }

        public bool UsuarioValido(LoginDto login)
        {
            try
            {

                var usuario = unitOfWork.Repository<UsuariosInformacionGeneral>().Where(x => x.Usuario == login.USuario).FirstOrDefault();
                if (usuario == null)
                {
                    return false;
                }
                login.UsuarioId = usuario.Id;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public RespuestaData<Productos> GuardarProducto(ProductoDto producto)
        {
            RespuestaData<Productos> respuesta = new RespuestaData<Productos>()
            {
                MensajeRespuesta = "Ok"
            };
            try
            {

                List<ProductosDetalle> detalles = new List<ProductosDetalle>();
                ProductosDetalle detalle = new ProductosDetalle()
                {
                    Activo = true,
                    Precio = producto.Precio,
                    EstadoID = 1,
                    UsuarioIngresa = this.login.UsuarioId,
                    FechaIngreso = DateTime.Now,
                    Observacion = producto.Observaciones,
                    ZONAID = 1,

                };
                detalles.Add(detalle);
                Productos productoEntity = new Productos()
                {
                    Activo = true,
                    Descripcion = producto.NombreProducto,
                    ProductosDetalles = detalles
                };
                int Id = unitOfWork.Repository<Productos>().Add(productoEntity).Id;
                detalle.ProductoId = productoEntity.Id;
                //unitOfWork.Repository<ProductosDetalle>().Add(detalle);
                unitOfWork.SaveChanges();

                respuesta.Data = productoEntity;

                return respuesta;
            }
            catch (Exception ex)
            {
                return new RespuestaData<Productos>()
                {
                    MensajeRespuesta = "Ha ocurrido un error",
                };

            }

        }

        public RespuestaData<List<spReporteProductosDisponibleParaAsignarPorEstados>> ObtenerProductos()
        {
            try
            {
                RespuestaData<List<spReporteProductosDisponibleParaAsignarPorEstados>> respuesta = new RespuestaData<List<spReporteProductosDisponibleParaAsignarPorEstados>>();
                string query = "exec [spReporteProductosDisponibleParaAsignarPorEstados] " + login.UsuarioId.ToString();
                SqlDataAdapter dataProcedureProductoss = new SqlDataAdapter(query, Properties.Settings.Default.ConnectionBd);
                DataTable dataListado = new DataTable();
                dataProcedureProductoss.Fill(dataListado);

                if (dataListado.Rows.Count == 0)
                {
                    respuesta.MensajeRespuesta = "No se encontró información";
                    return respuesta;
                }

                List<spReporteProductosDisponibleParaAsignarPorEstados> listadoRespuesto = new List<spReporteProductosDisponibleParaAsignarPorEstados>();

                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    spReporteProductosDisponibleParaAsignarPorEstados dataProcedure = new spReporteProductosDisponibleParaAsignarPorEstados()
                    {
                        Cantidad = int.Parse(dataListado.Rows[i].ItemArray[0].ToString()),
                        ProductoId = int.Parse(dataListado.Rows[i].ItemArray[1].ToString()),
                        Descripcion = dataListado.Rows[i].ItemArray[2].ToString(),
                        EstadoID = int.Parse(dataListado.Rows[3].ItemArray[3].ToString()),
                        Estado = dataListado.Rows[i].ItemArray[4].ToString(),
                        Observacion = dataListado.Rows[i].ItemArray[5].ToString(),

                    };
                    listadoRespuesto.Add(dataProcedure);

                }
                respuesta.Data = listadoRespuesto;
                respuesta.MensajeRespuesta = "Ok";
                return respuesta;

            }
            catch (Exception ex)
            {

                return new RespuestaData<List<spReporteProductosDisponibleParaAsignarPorEstados>>()
                {
                    MensajeRespuesta = "Ha ocurrido un error"
                };
            }
        }


    }
}
