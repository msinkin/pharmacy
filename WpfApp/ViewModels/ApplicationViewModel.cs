using System.Collections.ObjectModel;
using WpfApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Services;
using System;
using System.Windows;
using System.Linq;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// Основаная ViewModel приложения
    /// </summary>
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private IDrugService _drugsService;
        private IDrugManufactureService _drugsManufactureService;

        public ObservableCollection<DrugModel> Drugs { get; set; } = new ObservableCollection<DrugModel>();
        public ObservableCollection<DrugManufacturerModel> DrugManufactures { get; set; } = new ObservableCollection<DrugManufacturerModel>();

        private DrugModel _selectedDrug;

        private RelayCommand _addDrugCommand;
        private RelayCommand _saveDrugCommand;
        private RelayCommand _updateDrugCommand;
        private RelayCommand _removeDrugCommand;

        private RelayCommand _loadDatabaseCommand;

        public ApplicationViewModel(IDrugService drugService, IDrugManufactureService drugManufactureService)
        {
            _drugsService = drugService;
            _drugsManufactureService = drugManufactureService;
        }

        /// <summary>
        /// Выбранный препарат
        /// </summary>
        public DrugModel SelectedDrug
        {
            get { return _selectedDrug; }
            set
            {
                _selectedDrug = value;
                OnPropertyChanged(nameof(SelectedDrug));
            }
        }
        /// <summary>
        /// Команда для создания препарата (локанльно)
        /// </summary>
        public RelayCommand AddDrugCommand
        {
            get
            {
                return _addDrugCommand ??
                  (_addDrugCommand = new RelayCommand(obj =>
                  {
                      DrugModel drug = new DrugModel();
                      Drugs.Insert(0, drug);
                      SelectedDrug = drug;
                  }));
            }
        }
        /// <summary>
        /// Сохраняет локально созданный препарат
        /// </summary>
        public RelayCommand SaveDrugCommand
        {
            get
            {
                return _saveDrugCommand ??
                  (_saveDrugCommand = new RelayCommand(async (obj) =>
                  {
                      try
                      {
                          var drug = await _drugsService.CreateDrugAsync(SelectedDrug);
                          SelectedDrug.Id = drug.Id;
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message, "Оишбка API во врмея запроса", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                  }, (obj) => SelectedDrug?.Id == Guid.Empty && SelectedDrug?.Manufacturer != null));
            }
        }
        /// <summary>
        /// Обновляет препарат
        /// </summary>
        public RelayCommand UpdateDrugCommand
        {
            get
            {
                return _updateDrugCommand ??
                  (_updateDrugCommand = new RelayCommand(async obj =>
                  {
                      try
                      {
                          await _drugsService.UpdateDrugAsync(SelectedDrug);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message, "Оишбка API во врмея запроса", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                  },
                  (obj) => SelectedDrug?.Id != Guid.Empty && SelectedDrug?.Manufacturer != null));
            }
        }
        /// <summary>
        /// Команда удаления препарата
        /// </summary>
        public RelayCommand RemoveDrugCommand
        {
            get
            {
                return _removeDrugCommand ??
                  (_removeDrugCommand = new RelayCommand(async obj =>
                  {
                      if (SelectedDrug != null)
                      {
                          try
                          {
                              if (SelectedDrug.Id != Guid.Empty)
                                  await _drugsService.RemoveDrugAsync(SelectedDrug.Id);

                              Drugs.Remove(SelectedDrug);
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message, "Оишбка API во врмея запроса", MessageBoxButton.OK, MessageBoxImage.Error);
                          }
                      }
                  },
                 (obj) => Drugs.Count > 0));
            }
        }
        /// <summary>
        /// Команда для загрузки данных из бд
        /// </summary>
        public RelayCommand LoadDatabaseCommand
        {
            get
            {
                return _loadDatabaseCommand ??
                  (_loadDatabaseCommand = new RelayCommand(async obj =>
                  {
                      try
                      {
                          var drugs = await _drugsService.GetDrugsAsync();
                          var drugsManufactures = await _drugsManufactureService.GetDrugsManufacturersAsync();

                          Drugs.Clear();
                          DrugManufactures.Clear();

                          drugs.ToList().ForEach(Drugs.Add);
                          drugsManufactures.ToList().ForEach(DrugManufactures.Add);
                      } catch (Exception ex)
                      {
                          Drugs.Clear();
                          DrugManufactures.Clear();

                          MessageBox.Show(ex.Message, "Оишбка API во врмея запроса", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                  }));
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
