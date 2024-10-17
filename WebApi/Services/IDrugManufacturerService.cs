using WebApi.Entities;

namespace WebApi.Services
{
    public interface IDrugManufacturerService
    {
        Task<IEnumerable<DrugManufacturerEntity>> GetDrugManufacturersAsync();
        Task CreateDrugManufacturerAsync(DrugManufacturerEntity drugEntity);
        Task DeleteDrugManufacturerByIdAsync(Guid it);
        Task<DrugManufacturerEntity> UpdateDrugManufacturerAsync(DrugManufacturerEntity drugEntity);
    }
}
