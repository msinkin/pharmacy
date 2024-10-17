using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    /// <summary>
    /// Интерфейс взаимодействия с API препаратов
    /// </summary>
    internal interface IDrugService
    {
        /// <summary>
        /// Получить все препараты
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DrugModel>> GetDrugsAsync();
        /// <summary>
        /// Удалить препарат
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveDrugAsync(Guid id);
        /// <summary>
        /// Обновить информацию о препарате
        /// </summary>
        /// <returns></returns>
        Task<DrugModel> UpdateDrugAsync(DrugModel drugModel);
        /// <summary>
        /// Создать новый препарат
        /// </summary>
        /// <returns></returns>
        Task<DrugModel> CreateDrugAsync(DrugModel drugModel);
    }
}
