using ProductManagement.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Api.Data.Interface
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
    }
}
