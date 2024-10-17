using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Entities
{
    /// <summary>
    /// Модель таблицы Производитель товара
    /// </summary>
    [Table("drug_manufacturer")]
    public class DrugManufacturerEntity
    {
        /// <summary>
        /// Идентификатор производителя препаратов
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование производителя товаров
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Препараты которые соответсвуют этому производителю
        /// </summary>
        [JsonIgnore]
        public List<DrugEntity>? DrugEntities { get; set; }
    }
}
