using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayerProject.Core.Model
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>(); //ilk oluşturuldupunda boi bir tane collenction nesnesi oluşturuyor 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
