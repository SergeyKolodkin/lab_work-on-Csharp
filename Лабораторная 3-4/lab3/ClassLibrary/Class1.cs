using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace lab3
{
    [Serializable]

    public class Storage
    {
        public BindingList<Print> print_list = new BindingList<Print> { };
        public BindingList<Journal> journal_list = new BindingList<Journal> { };
        public BindingList<Book> book_list = new BindingList<Book> { };
        public BindingList<Textbook> textbook_list = new BindingList<Textbook> { };

        public void Add_print(Print print)
        {
            print_list.Add(print);
        }

        public void Add_journal(Journal temp)
        {
            journal_list.Add(temp);
        }

        public void Add_book(Book temp)
        {
            book_list.Add(temp);
        }

        public void Add_textbook(Textbook temp)
        {
            textbook_list.Add(temp);
        }
    }


    [Serializable]
    public class Print
    {
        protected string name;
        protected int year;
        protected int count;

        public string Name { get { return name; } set { name = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public Print(string _name, int _year, int _count)
        {
            name = _name;
            year = _year;
            count = _count;
        }

        public Print()
        {

        }

    }

    [Serializable]
    public class Journal : Print
    {
        private string periodicity;
        private string subjects;

        public string Periodicity { get { return periodicity; } set { periodicity = value; } }
        public string Subjects { get { return subjects; } set { subjects = value; } }

        public Journal(string _name, int _year, int _count, string _periodicity, string _subjects)
            : base(_name, _year, _count)
        {
            name = _name;
            year = _year;
            count = _count;
            periodicity = _periodicity;
            subjects = _subjects;
        }

        public Journal()
        {

        }
    }

    [Serializable]
    public class Book : Print
    {
        public string author;
        public string genre;

        public string Author { get { return author; } set { author = value; } }
        public string Genre { get { return genre; } set { genre = value; } }

        public Book(string _name, int _year, int _count, string _author, string _genre)
            : base(_name, _year, _count)
        {
            name = _name;
            year = _year;
            count = _count;
            author = _author;
            genre = _genre;
        }

        public Book()
        {

        }

    }

    [Serializable]
    public class Textbook : Print
    {
        public int grade;
        public string subject;

        public int Grade { get { return grade; } set { grade = value; } }
        public string Subject { get { return subject; } set { subject = value; } }

        public Textbook(string _name, int _year, int _count, int _grade, string _subject)
            : base(_name, _year, _count)
        {
            name = _name;
            year = _year;
            count = _count;
            grade = _grade;
            subject = _subject;
        }

        public Textbook()
        {

        }

    }
}
