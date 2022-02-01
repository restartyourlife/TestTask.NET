using System;
using System.Windows;
using TestTaskApplication.Model;
using TestTaskApplication.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace TestTaskApplication.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\employeesList.json";
        private FileIOService FileIOService;
        private ObservableCollection<Employee> _EmployeeCollection;
        private string _FilterString = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView EmployeeCollectionView { get; }

        public string[] SelectDepartments { get; private set; }

        public ApplicationViewModel()
        {
            FileIOService = new FileIOService(PATH);
            try
            {
                _EmployeeCollection = FileIOService.LoadData();
                EmployeeCollectionView = CollectionViewSource.GetDefaultView(_EmployeeCollection);
                EmployeeCollectionView.Filter = FilterEmployees;
                EmployeeCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(Employee.isFired)));
                EmployeeCollectionView.SortDescriptions.Add(new SortDescription(nameof(Employee.isFired), ListSortDirection.Ascending));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            SelectDepartments = new string[] { "Отдел снабжения", "Отдел кадров" };
        }

        private bool FilterEmployees(object obj)
        {
            if (obj is Employee employee)
            {
                return
                    employee.ID.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    employee.Surname.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    employee.Name.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    employee.Patronymic.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    employee.Position.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    employee.Salary.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    employee.Department.IndexOf(_FilterString, StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
            return false;
        }

        public string FilterString
        {
            get { return _FilterString; }
            set
            {
                Set(ref _FilterString, value);
                EmployeeCollectionView.Refresh();
            }
        }

        public ObservableCollection<Employee> EmployeeCollection 
        {
            get { return _EmployeeCollection; }
            private set 
            { 
                Set(ref _EmployeeCollection, value);
            }
        }

        public DelegateComand AddEmployee
        {
            get
            {
                return new DelegateComand(obj =>
                {
                    EmployeeCollection.Add(new Employee(EmployeeCollection.Count));
                });    
            }
        }

        public DelegateComand SaveCollectionEmployees 
        {
            get
            {
                return new DelegateComand(obj =>
                {
                    try
                    {
                        FileIOService.SaveData(EmployeeCollection);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}