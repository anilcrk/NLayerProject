using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Model;
using NLayerProject.Core.Repository;
using NLayerProject.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; } //ilgili context appdbContezte çevrildi
        public ProductRepository(AppDbContext context) : base(context) //repoository deki context e appDbConbtext set edildi
        {
                
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            var product = await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId); //iligili kategoriyide 
            return product;
        }
    }
}
