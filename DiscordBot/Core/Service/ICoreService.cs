using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Service
{
    public interface ICoreService<T> where T : BaseEntity
    {
        void Add(T model);
        void Add(List<T> models);
        T GetByID(Guid id);
        List<T> GetAll();
        List<T> GetActive();
        void Remove(Guid id);
        void Update(T model);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);

    }
}
