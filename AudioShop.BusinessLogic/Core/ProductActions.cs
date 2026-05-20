using System.Collections.Generic;
using System.Linq;
using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Product;
using AudioShop.Domains.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.BusinessLogic.Core
{
    public class ProductActions
    {
        protected AppDbContext _db = new AppDbContext();

        public List<ProductData> ExecuteGetAllProductsAction()
        {
            return _db.ProductDatas.ToList();
        }

        public ProductData ExecuteCreateNewProductsAction(ProductCreateDto _product)
        {
            ProductData newProduct = new ProductData()
            {
                Name = _product.Name,
                Description = _product.Description,
                Price = _product.Price,
                CategoryId = _product.CategoryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _db.ProductDatas.Add(newProduct);
            _db.SaveChanges();
            return newProduct;
        }
        public List<ProductData> ExecuteGetByCategoryProductsAction(string category)
        {
            return _db.ProductDatas
                .Include(p => p.Category)
                .Where(p => p.Category.Name.Contains(category))
                .ToList();
        }
        public ProductData ExecuteUpdateProductAction(int id, ProductCreateDto _product)
        {
            var product = _db.ProductDatas.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            product.Name = _product.Name;
            product.Description = _product.Description;
            product.Price = _product.Price;
            product.UpdatedAt = DateTime.Now;
            _db.SaveChanges();
            return product;
        }

        public bool ExecuteDeleteProductAction(int id)
        {
            var product = _db.ProductDatas.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;
            _db.ProductDatas.Remove(product);
            _db.SaveChanges();
            return true;
        }

        public ProductData ExecuteGetByIdProductAction(int id)
        {
            return _db.ProductDatas.FirstOrDefault(p => p.Id == id);
        }
    }
}