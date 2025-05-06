using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girrafe
{
    internal class Movie
    {
        public string title;
        public string director;
        private string rating;

        public Movie(string aTitle, string aDirector, string aRating)
        {
            title = aTitle;
            director = aDirector;
            Rating = aRating;
        }

        public string Rating
        {
            get { return rating; }
            set
            {
                if (value == "12+" || value == "14+" || value == "16+" || value == "18+")
                {
                    rating = value;
                }
                else
                {
                    rating = "18+";
                }
            }
        }

    }
}

