﻿using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);//hem product hemde o producta bağlı category de gelsin
    }
}
