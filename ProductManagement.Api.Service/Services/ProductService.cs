using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductManagement.Api.Common.Exceptions;
using ProductManagement.Api.Data.Interface;
using ProductManagement.Api.Data.Models;
using ProductManagement.Api.Model;
using ProductManagement.Api.Service.Interface;

namespace ProductManagement.Api.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        { 
            _mapper = mapper;
            _productRepository = productRepository;

        }
        public async Task<bool> DeleteProduct(int id)
        {
            var isDeleted  = await _productRepository.Delete(id);
            
            if (isDeleted == false)
                throw new AppException("Product not exist.");

            return true;
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProduct()
        {
            var result = _productRepository.GetAll().ToList();
            var res = _mapper.Map<IEnumerable<ProductDetails>>(result);
            return res;
        }
        
        public async Task<ProductDetails> GetProductById(int id)
        {
            var result = await _productRepository.GetById(id);

            if (result == null)
                throw new AppException("Product not exist.");

            var res = _mapper.Map<ProductDetails>(result);
            return res;
        }

        public async Task<ProductDetails> UpsertProduct(ProductDetails product)
        {
            var entity = _mapper.Map<Product>(product);

            if (product.ProductId == 0)
            {
                await _productRepository.Create(entity);
            }
            else
            {
                var result = await _productRepository.GetById(product.ProductId);

                if (result == null)
                    throw new AppException("Product not exist.");
                
                await _productRepository.Update(entity);
            }
            return _mapper.Map<ProductDetails>(entity);
            
        }
    }
}
