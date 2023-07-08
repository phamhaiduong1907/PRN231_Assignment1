using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductRepository : IProductRepository
    {
        Ass1Context _context;
        public ProductRepository() 
        {
            _context = new Ass1Context();
        }
        public async Task Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            name = name.ToLower().Trim();
            return await _context.Products.Where(p => p.ProductName.Contains(name)).Include(p => p.Category).AsNoTracking().ToListAsync();
        }

        public async Task Save(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            Product productToUpdate = await _context.Products.FindAsync(product.ProductId);
            if(productToUpdate != null)
            {
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Weight = product.Weight;
                productToUpdate.UnitsInStock = product.UnitsInStock;
                productToUpdate.CategoryId = product.CategoryId;
                _context.Products.Update(productToUpdate);
                await _context.SaveChangesAsync();
            }
            else 
            { 
                throw new Exception(); 
            }
        }
    }
}
