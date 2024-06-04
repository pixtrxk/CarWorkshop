using CarWorkshop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task Commit()
            => await _dbcontext.SaveChangesAsync();
        

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbcontext.Add(carWorkshop);
            await _dbcontext.SaveChangesAsync();
        }

		public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
			=> await _dbcontext.CarWorkshops.ToListAsync();

        public Task<Domain.Entities.CarWorkshop?> GetByEncodedName(string encodedName)
            => _dbcontext.CarWorkshops.FirstOrDefaultAsync(x => x.EncodedName == encodedName);

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name)
            =>	_dbcontext.CarWorkshops.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

        public async Task Delete(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbcontext.Remove(carWorkshop);
            await _dbcontext.SaveChangesAsync();
        }
	}
}
