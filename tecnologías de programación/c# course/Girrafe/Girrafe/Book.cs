using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girrafe
{
    internal class Book
    {
        public string title;
        public string author;
        public int pages;

        public Book(string aTitle, string anAuthor, int APages)
        {
            title = aTitle;
            author = anAuthor;
            pages = APages;
        }
    }
}
