using Bulutay.AdvertisementApp.DataAccess.Contexts;
using Bulutay.AdvertisementApp.DataAccess.Interfaces;
using Bulutay.AdvertisementApp.DataAccess.Repositories;
using Bulutay.AdvertisementApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulutay.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementAppContext _context;

        public Uow(AdvertisementAppContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
