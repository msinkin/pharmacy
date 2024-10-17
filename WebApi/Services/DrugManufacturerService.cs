using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Services
{
    public class DrugManufacturerService : IDrugManufacturerService
    {
        private readonly DataContext _dataContext;

        public DrugManufacturerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task CreateDrugManufacturerAsync(DrugManufacturerEntity drugEntity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDrugManufacturerByIdAsync(Guid it)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DrugManufacturerEntity>> GetDrugManufacturersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DrugManufacturerEntity> UpdateDrugManufacturerAsync(DrugManufacturerEntity drugEntity)
        {
            throw new NotImplementedException();
        }
    }
}
