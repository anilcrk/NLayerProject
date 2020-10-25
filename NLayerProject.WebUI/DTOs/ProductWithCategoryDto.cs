using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayerProject.WebUı.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        
        public CategoryDto Category{get;set;}
    }
}
