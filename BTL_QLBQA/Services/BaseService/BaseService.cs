using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Services.BaseService
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected readonly BTL_QLBQA.DataAccess.QLBQA_dbContext dbContext;
        public BaseService()
        {
            dbContext = new DataAccess.QLBQA_dbContext();
        }
        public BaseService(DataAccess.QLBQA_dbContext db)
        {
            dbContext = db;
        }
        public bool Delete(int Id)
        {
            T entity = GetByID(Id);
            if(entity != null)
            {
                return false;
            }
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
            return true;
        }

        public DbSet<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetByID(int Id)
        {
            return dbContext.Set<T>().Find(Id);
        }

        public T Insert(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            dbContext.Set<T>().AddOrUpdate(entity);
            dbContext.SaveChanges();
            return entity;
        }

    }
}
