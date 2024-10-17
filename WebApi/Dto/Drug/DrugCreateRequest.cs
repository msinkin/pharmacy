namespace WebApi.Dto.Drug
{
    /// <summary>
    /// DTO создания нового препарата
    /// </summary>
    /// <param name="Name">Название</param>
    /// <param name="Dosage">Дозировка (мг.)</param>
    /// <param name="Packaging">Кол-во шт.</param>
    /// <param name="DrugManufacturerId">Производитель препарата</param>
    public record struct DrugCreateRequest(
        string Name, 
        int Dosage, 
        int Packaging,
        Guid DrugManufacturerId
    );
}
