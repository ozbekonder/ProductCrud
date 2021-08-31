using ProductCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Repostories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public List<ProductViewModel> GetAllActiveProducts()
        {
            using var contex = new Contexts.ProjectDBContext();
            var list = contex.Product.Where(w => w.IsDeleted == false).Select(s => new ProductViewModel
            {
                ID = s.ID,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,
                Quantity = s.Quantity
            }).ToList();
            if (list == null)
                list = new List<ProductViewModel>();
            return list;
        }
        public ProductEditModel GetProduct(int id)
        {
            using var contex = new Contexts.ProjectDBContext();
            var product = contex.Product.Where(w => w.ID == id).Select(s => new ProductEditModel
            {
                ID = s.ID,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,
                Quantity = s.Quantity
            }).FirstOrDefault();
            return product;
        }
        public void CreateProduct(ProductCreateModel model)
        {
            Product product = new Product();
            product.ProductName = model.ProductName;
            product.ProductCode = model.ProductCode;
            product.Quantity = model.Quantity;
            product.CreatedAt = DateTime.Now;
            TAdd(product);
        }

        public void EditProduct(ProductEditModel model)
        {
            using var contex = new Contexts.ProjectDBContext();
            var product = contex.Product.Where(w => w.ID == model.ID).FirstOrDefault();
            product.ProductName = model.ProductName;
            product.ProductCode = model.ProductCode;
            product.Quantity = model.Quantity;
            product.UpdatedAt = DateTime.Now;
            TUpdate(product);
        }
        public void DeleteProduct(int id)
        {
            using var contex = new Contexts.ProjectDBContext();
            var product = contex.Product.Where(w => w.ID == id).FirstOrDefault();
            product.IsDeleted = true;
            product.UpdatedAt = DateTime.Now;
            TUpdate(product);
        }

    }
}
