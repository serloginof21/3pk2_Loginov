using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Input;
using System.Windows;

namespace PZ_11
{
    class BookViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        private string jsonFile = "BookCollection.json";
        public ICommand AddBookCommand { get; set; }

        public BookViewModel()
        {
            Books = new ObservableCollection<Book>();
            LoadBook();
            AddBookCommand = new RelayCommand
                ((p) =>
                {
                        var BookAdd = p as MainWindow;
                        string _title = BookAdd.tb1.Text;
                        string _year = BookAdd.tb2.Text;
                        string _author = BookAdd.tb3.Text;
                        if (!string.IsNullOrEmpty(_title) && !string.IsNullOrEmpty(_year))
                        {
                            AddBook(_title, _year, _author);
                            BookAdd.tb1.Text = _title;
                            BookAdd.tb2.Text = _year;
                            BookAdd.tb3.Text = _author;
                        }
                        MessageBox.Show("Книга добавлена в библиотеку");
                });
        }

        private void SaveBook()
        {
            var json = JsonConvert.SerializeObject(Books);
            File.AppendAllText(jsonFile, json);
        }
        private void LoadBook()
        {
            if (File.Exists(jsonFile))
            {
                var json = File.ReadAllText(jsonFile);
                var bookList = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                Books = bookList;
            }
        }
        private void AddBook(string bookTitle, string year, string author)
        {
            Books.Add(new Book(bookTitle, year, author));
            SaveBook();
        }
    }
}
