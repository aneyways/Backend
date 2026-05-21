using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic.Core;
using AudioShop.Domains.Models.Product;
using AudioShop.BusinessLogic.Interface;

namespace AudioShop.BusinessLogic.Functions
{
    public class ProductFlow : ProductActions, IProductActions
    {
        public List<ProductResponseDto> GetAllProductsAction()
        {
            var products = ExecuteGetAllProductsAction();
            List<ProductResponseDto> productsDto = new List<ProductResponseDto>();

            foreach (var product in products)
            {
                var productRespDto = new ProductResponseDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                };
                productsDto.Add(productRespDto);

            }
            return productsDto;
        }

        public ProductResponseDto CreateNewProductAction(ProductCreateDto _product)
        {
            var newProduct = ExecuteCreateNewProductsAction(_product);

            ProductResponseDto newProductDto = new ProductResponseDto()
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
            };

            return newProductDto;
        }

        public ProductResponseDto UpdateProductAction(int id, ProductCreateDto _product)
        {
            var updatedProduct = ExecuteUpdateProductAction(id, _product);

            ProductResponseDto updatedProductDto = new ProductResponseDto()
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Description = updatedProduct.Description,
            };

            return updatedProductDto;
        }

        public bool DeleteProductAction(int id)
        {

            return ExecuteDeleteProductAction(id);
        }

        public ProductResponseDto GetByIdProductAction(int id)
        {
            var foundProduct = ExecuteGetByIdProductAction(id);

            if (foundProduct == null) return null;

            ProductResponseDto foundProductDto = new ProductResponseDto()
            {
                Id = foundProduct.Id,
                Name = foundProduct.Name,
                Price = foundProduct.Price,
                Description = foundProduct.Description,
            };

            return foundProductDto;
        }

        public List<ProductResponseDto> GetByCategoryProductsAction(string _category)
        {
            var products = ExecuteGetByCategoryProductsAction(_category);
            List<ProductResponseDto> productsDto = new List<ProductResponseDto>();
            foreach (var product in products)
            {
                var productRespDto = new ProductResponseDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                };
                productsDto.Add(productRespDto);
            }
            return productsDto;
        }
    }
}