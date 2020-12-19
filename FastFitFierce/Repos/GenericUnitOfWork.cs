using FastFitFierce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFitFierce.Repos
{
    public class GenericUnitOfWork : IDisposable
    {
        private dbFFFEntities DbEntity = new dbFFFEntities();
        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GeneralRepository<Tbl_EntityType>(DbEntity);
        }

        public void SaveChanges()
        {
            DbEntity.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}