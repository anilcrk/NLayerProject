using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //bool ControlInnerBarcode(Product product);
        Task<Product> GetWithCategoryByIdAsync(int productId);//hem product hemde o producta bağlı category de gelsin
        //Product'ta özgü metodlar yazılabilir.
    }
}
