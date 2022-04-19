using PruebaCSharpProductos.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSharpProductos.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        ProductsDbContext context;
        public UnitOfWork(ProductsDbContext _context)
        {
            context = _context;
            
        }
      

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public DbSet<TEntity> Repository<TEntity>() where TEntity : class
        {
            DbSet<TEntity> dbSET = context.Set<TEntity>();
            return dbSET;
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Configurations.Add(new EstadoMap());
        //}
   

        public RespuestaData<TEntity> getEntityData<TEntity>(string query) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public string ChangeDatabase(ProductsDbContext source, string initialCatalog, string dataSource, string userId, string password, bool integratedSecuity, string configConnectionStringName)
        {
            throw new NotImplementedException();
        }
    }
}
