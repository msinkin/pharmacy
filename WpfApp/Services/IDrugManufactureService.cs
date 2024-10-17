using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    /// <summary>
    /// Интерфейс взаимодействия с API производителями препаратов
    /// </summary>
    internal interface IDrugManufactureService
    {
        /// <summary>
        /// Получить всех производителей препаратов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DrugManufacturerModel>> GetDrugsManufacturersAsync();
        /// <summary>
        /// Удалить производителя препарата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveDrugManufactureAsync(Guid id);
        /// <summary>
        /// Обновить информацию о производителе препаратов
        /// </summary>
        /// <returns></returns>
        Task UpdateDrugManufactureAsync();
        /// <summary>
        /// Добавить производителя препаратов
        /// </summary>
        /// <returns></returns>
        Task CreateDrugManufactureAsync();
    }
}
