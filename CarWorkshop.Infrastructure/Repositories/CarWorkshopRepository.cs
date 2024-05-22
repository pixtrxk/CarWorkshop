using CarWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbcontext;
        public CarWorkshopRepository(CarWorkshopDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbcontext.Add(carWorkshop);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
