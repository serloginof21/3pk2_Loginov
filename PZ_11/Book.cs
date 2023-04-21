using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_11
{
    class Book
    {
        public string BookTitle { get; set; }
        public string YearPublication { get; set; }
        public string Author { get; set; }

        public Book(string book, string year, string author) 
        {
            BookTitle = book;
            YearPublication = year;
            Author = author;
        }
    }
}
