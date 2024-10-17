using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WpfApp.Models
{
    internal class DrugModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private int _dosage;
        private int _packaging;
        private DrugManufacturerModel _manufacturer;

        /// <summary>
        /// Индетификатор
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        /// <summary>
        /// Наименование
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        /// <summary>
        /// Доизровка
        /// </summary>
        [JsonPropertyName("dosage")]
        public int Dosage
        {
            get => _dosage;
            set
            {
                _dosage = value;
                OnPropertyChanged(nameof(Dosage));
            }
        }
        /// <summary>
        /// Кол-во
        /// </summary>
        [JsonPropertyName("packaging")]
        public int Packaging
        {
            get => _packaging;
            set
            {
                _packaging = value;
                OnPropertyChanged(nameof(Packaging));
            }
        }
        /// <summary>
        /// Производитель
        /// </summary>
        [JsonPropertyName("manufacturer")]
        public DrugManufacturerModel Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(Manufacturer));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
