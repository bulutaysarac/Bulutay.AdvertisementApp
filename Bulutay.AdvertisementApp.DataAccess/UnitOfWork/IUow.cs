using Bulutay.AdvertisementApp.DataAccess.Interfaces;
using Bulutay.AdvertisementApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulutay.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
