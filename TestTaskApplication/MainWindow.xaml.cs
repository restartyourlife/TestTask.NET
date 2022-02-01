using System.Windows;
using TestTaskApplication.ViewModel;

namespace TestTaskApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationViewModel applicationViewModel = new ApplicationViewModel();
            DataContext = applicationViewModel;
            DataGridComboBoxColumnDepartments.ItemsSource = applicationViewModel.SelectDepartments;
        }
    }
}
