using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Services
{
    public class DrugService : IDrugService
    {
        private readonly DataContext _dataContext;

        public DrugService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<DrugEntity> CreateDrugAsync(DrugEntity drugEntity)
        {
            _dataContext.DrugEntities.Add(drugEntity);

            await _dataContext.SaveChangesAsync();

            return drugEntity;
        }

        public async Task RemoveDrugByIdAsync(Guid it)
        {
            DrugEntity drug = new DrugEntity() { Id = it };
            _dataContext.DrugEntities.Attach(drug);
            _dataContext.DrugEntities.Remove(drug);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DrugEntity>> GetDrugsAsync()
        {
            return await _dataContext.DrugEntities.Include(d => d.Manufacturer).ToListAsync();
        }

        public async Task<DrugEntity> UpdateDrugAsync(DrugEntity drugEntity)
        {
            _dataContext.Entry(drugEntity).State = EntityState.Modified;

            await _dataContext.SaveChangesAsync();

            return drugEntity;
        }
    }
}
