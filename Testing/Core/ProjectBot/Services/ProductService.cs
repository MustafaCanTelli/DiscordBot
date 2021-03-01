using Core;
using Core.Service;
using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBot.Services
{
    public interface IProductService
    {
        Task CreateNewProduct(Product product);
        Task<Product> GetProductByName(string productName);
    }

    public class ProductService : IProductService
    {
        private readonly ProjectDbContext _db;

        public ProductService(ProjectDbContext db)
        {
            _db = db;
        }

        public Task CreateNewProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByName(string productName)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductServiceBase<T> : ICoreService<T> where T : BaseEntity
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
