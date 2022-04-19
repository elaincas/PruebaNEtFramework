using PruebaCSharpProductos.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Dispose();
        DbSet<TEntity> Repository<TEntity>() where TEntity : class;
        RespuestaData<TEntity> getEntityData<TEntity>(string query) where TEntity : class;

        string ChangeDatabase(
                    ProductsDbContext source,
                   string initialCatalog,
                   string dataSource,
                   string userId,
                   string password,
                   bool integratedSecuity ,
                   string configConnectionStringName );
        void SaveChangesAsync();
        void SaveChanges();
    }
}
