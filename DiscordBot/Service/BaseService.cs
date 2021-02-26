using Core;
using Core.Service;
using DataAccess.Context;
using Service.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class BaseService<T> : ICoreService<T> where T : BaseEntity
    {
        IceCrownDbContext db = Singleton.Context;
        public void Add(T model)
        {
            model.ID = Guid.NewGuid();
            db.Set<T>().Add(model);
            db.SaveChanges();            
        }

        public void Add(List<T> models)
        {
            foreach (T model in models)
            {
                model.ID = Guid.NewGuid();
            }
            db.Set<T>().AddRange(models);
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
           return db.Set<T>().Where(x => x.Status == Core.Enums.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetByID(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            var model = GetByID(id);
            model.Status = Core.Enums.Status.Deleted;
            db.SaveChanges();

        }

        public void Update(T model)
        {
            T update = GetByID(model.ID);

            DbEntityEntry entry = db.Entry(update);
            entry.CurrentValues.SetValues(model);
            db.SaveChanges();
        }
    }
}
