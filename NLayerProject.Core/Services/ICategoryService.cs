using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
   public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId); //hem kategori hemde kategoriye bağlı productlar döneceek
        //Category'ye ait metodlar yazılabilir.
    }
}
