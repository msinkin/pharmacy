using WebApi.Entities;

namespace WebApi.Services
{
    /// <summary>
    /// Интерфейс взаимодействия с базой данных для препаратов
    /// </summary>
    public interface IDrugService
    {
        /// <summary>
        /// Получить все препараты
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DrugEntity>> GetDrugsAsync();
        /// <summary>
        /// Создать препарат
        /// </summary>
        /// <param name="drugEntity"></param>
        /// <returns></returns>
        Task<DrugEntity> CreateDrugAsync(DrugEntity drugEntity);
        /// <summary>
        /// Удаление препарата по индетификатору
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        Task RemoveDrugByIdAsync(Guid it);
        /// <summary>
        /// Обновление данных о препарате
        /// </summary>
        /// <param name="drugEntity"></param>
        /// <returns></returns>
        Task<DrugEntity> UpdateDrugAsync(DrugEntity drugEntity);
    }
}
