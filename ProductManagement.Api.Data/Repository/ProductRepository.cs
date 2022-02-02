using ProductManagement.Api.Data.Interface;
using ProductManagement.Api.Data.Models;


namespace ProductManagement.Api.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
