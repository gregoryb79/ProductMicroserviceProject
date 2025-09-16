using Microsoft.EntityFrameworkCore;
using ProductMicroserviceProject.Models;

namespace ProductMicroserviceProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dBcontext;
        public ProductRepository(ApplicationDbContext context)
        {
            _dBcontext = context;
        }
        public void DeleteProduct(int productId)
        {
            var product = _dBcontext.Products.Find(productId);
            if (product != null)
            {
                _dBcontext.Products.Remove(product);
                Save();
            }
        }

        public Product GetProductById(int productId)
        {
            return _dBcontext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dBcontext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {

            _dBcontext.Products.Add(product);
            Save();
        }

        public void Save()
        {
            _dBcontext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dBcontext.Products.Update(product);            
            Save();
        }
    }
}
