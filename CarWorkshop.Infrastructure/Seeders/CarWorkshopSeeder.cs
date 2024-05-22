using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbcontext;
        public CarWorkshopSeeder(CarWorkshopDbContext dbcontext)
        {
            _dbcontext = dbcontext;            
        }
        public async Task Seed()
        {
            if(await _dbcontext.Database.CanConnectAsync())
            {
                if(!_dbcontext.CarWorkshops.Any())
                {
                    var audiAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Audi ASO",
                        Description = "Autoryzowany serwis Audi",
                        ContactDetails = new()
                        {
                            PhoneNumber = "+48667485900",
                            Street = "Zamojska 74",
                            City = "Warszawa",
                            PostalCode = "00-097"
                        }
                    };

                    audiAso.EncodeName();
                    _dbcontext.CarWorkshops.Add(audiAso);
                    await _dbcontext.SaveChangesAsync();

                }
            }
        }
    }
}
