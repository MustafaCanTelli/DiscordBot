using Core;
using Core.Service;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class BaseService<T> : ICoreService<T> where T : BaseEntity
    {
       

        public void Add(T model)
        {
            throw new NotImplementedException();
        }

        public void Add(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public List<T> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetbyId(T id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Remove(T id)
        {
            throw new NotImplementedException();
        }
    }
}
