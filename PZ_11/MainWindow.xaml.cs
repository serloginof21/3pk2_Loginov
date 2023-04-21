using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace PZ_11
{
    public partial class MainWindow : Window
    {
        private string jsonFile = "BookCollection.json";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new BookViewModel();
            if (File.Exists(jsonFile))
            {
                var json = File.ReadAllText(jsonFile);
                var bookList = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                List<String> IsData = new List<String>();
                for(int i = 0; i < bookList.Count; i++)
                {
                    IsData.Add($"Название:{bookList[i].BookTitle} Имя Автора: {bookList[i].YearPublication} Дата Издания:{bookList[i].Author}");
                    lst1.ItemsSource = IsData;
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(jsonFile))
            {
                var json = File.ReadAllText(jsonFile);
                var bookList = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                List<String> IsData = new List<String>();
                for (int i = 0; i < bookList.Count; i++)
                {
                    IsData.Add($"Название:{bookList[i].BookTitle} Имя Автора: {bookList[i].YearPublication} Дата Издания:{bookList[i].Author}");
                    lst1.ItemsSource = IsData;
                }
            }
        }
    }
}
