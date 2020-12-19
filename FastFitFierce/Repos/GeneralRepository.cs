using FastFitFierce.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FastFitFierce.Repos
{
    public class GeneralRepository<Tbl_Entity> : IRepository<Tbl_Entity> where Tbl_Entity : class
    {
        DbSet<Tbl_Entity> _dbSet;
        private dbFFFEntities _DbEntity;

        public GeneralRepository(dbFFFEntities DbEntity)
        {
            _DbEntity = DbEntity;
            _dbSet = _DbEntity.Set<Tbl_Entity>();
        }

        public void Add(Tbl_Entity entity)
        {
            _dbSet.Add(entity);
            _DbEntity.SaveChanges();
        }

        public IEnumerable<Tbl_Entity> GetActiveProducts()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Tbl_Entity> GetAllRecords()
        {
            return _dbSet.ToList();
        }

        public int GetAllRecordsCount()
        {
            return _dbSet.Count();
        }

        public IQueryable<Tbl_Entity> GetAllRecordsIQueryable()
        {
            return _dbSet;
        }

        public Tbl_Entity GetFirstorDefault(int recordId)
        {
            return _dbSet.Find(recordId);
        }

        public Tbl_Entity GetFirstorDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<Tbl_Entity> GetRecordsToShow(int PageNumber, int PageSize, int CurrentPage, Expression<Func<Tbl_Entity, bool>> wherePredict, Expression<Func<Tbl_Entity, int>> orderByPredict)
        {
            if (wherePredict != null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }

        public IEnumerable<Tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters)
        {
            if (parameters != null)
            {
                return _DbEntity.Database.SqlQuery<Tbl_Entity>(query, parameters).ToList();
            }
            else
            {
                return _DbEntity.Database.SqlQuery<Tbl_Entity>(query).ToList();
            }
        }

        public void InacitveAndDeleteMarkByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(Tbl_Entity entity)
        {
            if (_DbEntity.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void RemoveByWwhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            Tbl_Entity entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            List<Tbl_Entity> entities = _dbSet.Where(wherePredict).ToList();
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Update(Tbl_Entity entity)
        {
            _dbSet.Attach(entity);
            _DbEntity.Entry(entity).State = EntityState.Modified;
            _DbEntity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

    }
}