using NLayerProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWork
{
   public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Category { get; }
        Task CommitAsync();
        void Commit();
    }
}
