using NLayerProject.Core.Model;
using NLayerProject.Core.Repository;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            var result = await _unitOfWork.Category.GetWithProductsByIdAsync(categoryId);
            return result;
        }
    }
}
