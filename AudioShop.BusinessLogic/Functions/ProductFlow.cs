using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic.Core;
using AudioShop.Domains.Models.Product;
using AudioShop.BusinessLogic.Interface;
using AudioShop.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.BusinessLogic.Functions
{
    public class ProductFlow : ProductActions, IProductActions
    {
        public List<ProductResponseDto> GetAllProductsAction()
        {
            var products = _db.ProductDatas
                .Include(p => p.Category)
                .Include(p => p.Images)
                .ToList();

            List<ProductResponseDto> productsDto = new List<ProductResponseDto>();
            foreach (var product in products)
            {
                var productRespDto = new ProductResponseDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Category = product.Category?.Name,
                    Images = product.Images?.Select(i => new ProductImageResponseDto
                    {
                        Id = i.Id,
                        Url = i.Url,
                        ProductId = i.ProductId
                    }).ToList() ?? new()
                };
                productsDto.Add(productRespDto);
            }
            return productsDto;
        }

        public ProductResponseDto CreateNewProductAction(ProductCreateDto _product)
        {
            var newProduct = ExecuteCreateNewProductsAction(_product);

            var productWithCategory = _db.ProductDatas
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == newProduct.Id);

            return new ProductResponseDto()
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                Category = productWithCategory?.Category?.Name,
                Images = productWithCategory?.Images?.Select(i => new ProductImageResponseDto
                {
                    Id = i.Id,
                    Url = i.Url,
                    ProductId = i.ProductId
                }).ToList() ?? new()
            };
        }

        public ProductResponseDto UpdateProductAction(int id, ProductCreateDto _product)
        {
            var updatedProduct = ExecuteUpdateProductAction(id, _product);

            var productWithCategory = _db.ProductDatas
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == updatedProduct.Id);

            return new ProductResponseDto()
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Description = updatedProduct.Description,
                Category = productWithCategory?.Category?.Name,
                Images = productWithCategory?.Images?.Select(i => new ProductImageResponseDto
                {
                    Id = i.Id,
                    Url = i.Url,
                    ProductId = i.ProductId
                }).ToList() ?? new()
            };
        }

        public bool DeleteProductAction(int id)
        {
            return ExecuteDeleteProductAction(id);
        }

        public ProductResponseDto GetByIdProductAction(int id)
        {
            var foundProduct = _db.ProductDatas
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);

            if (foundProduct == null) return null;

            return new ProductResponseDto()
            {
                Id = foundProduct.Id,
                Name = foundProduct.Name,
                Price = foundProduct.Price,
                Description = foundProduct.Description,
                Category = foundProduct.Category?.Name,
                Images = foundProduct.Images?.Select(i => new ProductImageResponseDto
                {
                    Id = i.Id,
                    Url = i.Url,
                    ProductId = i.ProductId
                }).ToList() ?? new()
            };
        }

        public List<ProductResponseDto> GetByCategoryProductsAction(string _category)
        {
            var products = _db.ProductDatas
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Where(p => p.Category.Name.Contains(_category))
                .ToList();

            List<ProductResponseDto> productsDto = new List<ProductResponseDto>();
            foreach (var product in products)
            {
                var productRespDto = new ProductResponseDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Category = product.Category?.Name,
                    Images = product.Images?.Select(i => new ProductImageResponseDto
                    {
                        Id = i.Id,
                        Url = i.Url,
                        ProductId = i.ProductId
                    }).ToList() ?? new()
                };
                productsDto.Add(productRespDto);
            }
            return productsDto;
        }

        public ProductResponseDto AddProductImageAction(int productId, string url)
        {
            var product = ExecuteAddProductImageAction(productId, url);
            if (product == null) return null;

            return new ProductResponseDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category?.Name,
                Images = product.Images?.Select(i => new ProductImageResponseDto
                {
                    Id = i.Id,
                    Url = i.Url,
                    ProductId = i.ProductId
                }).ToList() ?? new()
            };
        }
        public ProductResponseDto UpdateProductImageAction(int productId, string url)
        {
            var product = ExecuteUpdateProductImageAction(productId, url);
            if (product == null) return null;

            return new ProductResponseDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category?.Name,
                Images = product.Images?.Select(i => new ProductImageResponseDto
                {
                    Id = i.Id,
                    Url = i.Url,
                    ProductId = i.ProductId
                }).ToList() ?? new()
            };
        }
    }
}