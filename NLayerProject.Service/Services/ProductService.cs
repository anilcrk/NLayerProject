using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using NLayerProject.Core.Model;
using NLayerProject.Core.Repository;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork,IRepository<Product>repository):base(unitOfWork,repository)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            var result = await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
            return result;
        }
    }
}
