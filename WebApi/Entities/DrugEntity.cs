using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    /// <summary>
    /// Фармацевтический препарат
    /// </summary>
    [Table("drugs")]
    public class DrugEntity
    {
        /// <summary>
        /// Идентификатор препарата
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование препарата
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дозировка препарата в мг. (например 100 мг.)
        /// </summary>
        public int Dosage { get; set; }
        /// <summary>
        /// Фасовка препарата в шт. (например 10 шт.)
        /// </summary>
        public int Packaging { get; set; }
        /// <summary>
        /// Идентификатор Форма выпуска препарата
        /// </summary>
        public Guid DrugManufacturerId { get; set; }
        /// <summary>
        /// Фирма производитель препарата
        /// </summary>
        [ForeignKey(nameof(DrugManufacturerId))]
        public DrugManufacturerEntity Manufacturer { get; set; }
    }
}
