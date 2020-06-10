using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba1
{
    public class Print
    {
        private string name;
        private string author;
        private int year;
        private int count;
        private int sales;

        public string Name
        {
            get{return name;}
            set{name=value;}
        }
        public string Author
        {
            get{return author;}
            set{author=value;}
        }
        public int Year
        {
            get{return year;}
            set{year=value;}
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public bool Add_year(string s_year)
        {
            if (int.TryParse(s_year, out year)&((year > 0) && (year < 2015)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add_count(string s_count)
        {
            if (int.TryParse(s_count, out count) & (0 < count))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add_sales(string s_sales)
        {
            if (int.TryParse(s_sales, out sales) & (-1 < sales))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
