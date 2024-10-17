using WebApi.Entities;

namespace WebApi.Dto.Drug
{
    /// <summary>
    /// Формат ответа Api для вывода препарата
    /// </summary>
    /// <param name="Id">Индетификатор</param>
    /// <param name="Name">Наименование</param>
    /// <param name="Dosage">Дозировка</param>
    /// <param name="Packaging">Кол-во</param>
    /// <param name="Manufacturer">Производитель</param>
    public record struct DrugResponse(
        Guid Id,
        string Name,
        int Dosage,
        int Packaging,
        DrugManufacturerEntity Manufacturer
    );
}
