using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NLayerProject.Core.Model
{
   public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Stock{ get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public string InnerBarcode { get; set; }
        public virtual Category Category { get; set; } //Category tablosuna referans veriyoruz çünkü ef kategori üzerinde izleme yapabilsin ve kayıt altına akınabilsin
    }
}
