namespace WebApi.Dto.DrugManufacturer
{
    /// <summary>
    /// DTO создания нового производителя
    /// </summary>
    /// <param name="Name">Наименование</param>
    public record struct DrugManufacturerCreateRequest(string Name);
}
