using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using TestTaskApplication.Model;

namespace TestTaskApplication.Services
{
    interface IFileService
    {
        ObservableCollection<Employee> LoadData();
        void SaveData(object employees);
    };

    class FileIOService: IFileService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public ObservableCollection<Employee> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<Employee>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Employee>>(fileText);
            }
        }

        public void SaveData(object employees)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(employees);
                writer.Write(output);
            }
        }
    }
}
