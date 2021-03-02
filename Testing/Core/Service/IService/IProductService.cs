using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
    }
}
