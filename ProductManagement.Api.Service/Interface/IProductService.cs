using ProductManagement.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Api.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDetails> UpsertProduct(ProductDetails product);
        Task<IEnumerable<ProductDetails>> GetAllProduct();
        Task<ProductDetails> GetProductById(int id);
        Task<bool> DeleteProduct(int id);
    }
}
