using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Linq;

namespace lab3
{
    public partial class Form1 : Form
    {
        Storage storage = new Storage();

        public Form1()
        {
            InitializeComponent();
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            Print temp = new Print (print_textbox_name.Text, (int)print_num_year.Value, (int)print_num_count.Value);
            storage.Add_print(temp);
            print_view.DataSource = storage.print_list;
            print_view.Enabled = true;
            Refresh(1);
        }

        private void journal_button_Click(object sender, EventArgs e)
        {
            Journal temp = new Journal(journal_textbox_name.Text, (int)journal_num_year.Value, (int)journal_num_count.Value, journal_textbox_periodicity.Text, journal_textbox_subjects.Text);
            storage.Add_journal(temp);
            journal_view.DataSource = storage.journal_list;
            journal_view.Enabled = true;
            Refresh(2);
        }

        private void book_button_Click(object sender, EventArgs e)
        {
            Book temp = new Book(book_textbox_name.Text, (int)book_num_year.Value, (int)book_num_count.Value, book_textbox_author.Text, book_textbox_genre.Text);
            storage.Add_book(temp);
            book_view.DataSource = storage.book_list;
            book_view.Enabled = true;
            Refresh(3);
        }

        private void textbook_button_Click(object sender, EventArgs e)
        {
            Textbook temp = new Textbook(textbook_textbox_name.Text, (int)textbook_num_year.Value, (int)textbook_num_count.Value, (int)textbook_num_grade.Value, textbook_textbox_subject.Text);
            storage.Add_textbook(temp);
            textbook_view.DataSource = storage.textbook_list;
            textbook_view.Enabled = true;
            Refresh(4);
        }

        private void serialization_menu_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file = new SaveFileDialog();
            save_file.Filter = "XML файлы | *.xml";
            if (save_file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Storage));
                    StreamWriter wr = new StreamWriter(save_file.FileName);
                    ser.Serialize(wr, storage);
                    wr.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error =(");
                }
            }
        }

        private void deserialization_menu_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "XML файлы | *.xml";
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Storage));
                    StreamReader read = new StreamReader(open_file.FileName);
                    storage = (Storage)ser.Deserialize(read);
                    read.Close();
                    print_view.DataSource = storage.print_list;
                    print_view.Enabled = true;
                    journal_view.DataSource = storage.journal_list;
                    journal_view.Enabled = true;
                    book_view.DataSource = storage.book_list;
                    book_view.Enabled = true;
                    textbook_view.DataSource = storage.textbook_list;
                    textbook_view.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error =(");
                }
            }
        }




        private void search_button_name_Click(object sender, EventArgs e)
        {
            List<Print> search_list = new List<Print> { };
            search_list.Clear();
            
            search_list.AddRange(storage.print_list.Where(m => m.Name == search_name.Text).ToList());
            search_list.AddRange(storage.journal_list.Where(m => m.Name == search_name.Text).ToList<Print>());
            search_list.AddRange(storage.book_list.Where(m => m.Name == search_name.Text).ToList<Print>());
            search_list.AddRange(storage.textbook_list.Where(m => m.Name == search_name.Text).ToList<Print>());
            
            search_view.DataSource = search_list;
        }

        private void search_button_year_Click(object sender, EventArgs e)
        {
            List<Print> search_list = new List<Print> { };
            search_list.Clear();

            search_list.AddRange(storage.print_list.Where(m => m.Year.ToString() == search_year.Text).ToList());
            search_list.AddRange(storage.journal_list.Where(m => m.Year.ToString() == search_year.Text).ToList<Print>());
            search_list.AddRange(storage.book_list.Where(m => m.Year.ToString() == search_year.Text).ToList<Print>());
            search_list.AddRange(storage.textbook_list.Where(m => m.Year.ToString() == search_year.Text).ToList<Print>());

            search_view.DataSource = search_list;
        }

        private void search_button_count_Click(object sender, EventArgs e)
        {
            List<Print> search_list = new List<Print> { };
            search_list.Clear();

            search_list.AddRange(storage.print_list.Where(m => m.Count.ToString() == search_count.Text).ToList());
            search_list.AddRange(storage.journal_list.Where(m => m.Count.ToString() == search_count.Text).ToList<Print>());
            search_list.AddRange(storage.book_list.Where(m => m.Count.ToString() == search_count.Text).ToList<Print>());
            search_list.AddRange(storage.textbook_list.Where(m => m.Count.ToString() == search_count.Text).ToList<Print>());

            search_view.DataSource = search_list;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            List<Print> search_list = new List<Print> { };
            search_list.Clear();

            search_list.AddRange(storage.print_list.Where(m => m.Name == search_name.Text).Where(m => m.Year.ToString() == search_year.Text).Where(m => m.Count.ToString() == search_count.Text).ToList());
            search_list.AddRange(storage.journal_list.Where(m => m.Name == search_name.Text).Where(m => m.Year.ToString() == search_year.Text).Where(m => m.Count.ToString() == search_count.Text).ToList<Print>());
            search_list.AddRange(storage.book_list.Where(m => m.Name == search_name.Text).Where(m => m.Year.ToString() == search_year.Text).Where(m => m.Count.ToString() == search_count.Text).ToList<Print>());
            search_list.AddRange(storage.textbook_list.Where(m => m.Name == search_name.Text).Where(m => m.Year.ToString() == search_year.Text).Where(m => m.Count.ToString() == search_count.Text).ToList<Print>());
            
            search_view.DataSource = search_list;
        }


        void Refresh(int section)
        {
            switch (section)
            {
                case 1:
                    {
                        print_textbox_name.Clear();
                        print_num_year.Value = 2014;
                        print_num_count.Value = 2014;
                        break;
                    }
                case 2:
                    {
                        journal_textbox_name.Clear();
                        journal_num_year.Value = 2014;
                        journal_num_count.Value = 2014;
                        journal_textbox_periodicity.Clear();
                        journal_textbox_subjects.Clear();
                        break;
                    }
                case 3:
                    {
                        book_textbox_name.Clear();
                        book_num_year.Value = 2014;
                        book_num_count.Value = 2014;
                        book_textbox_author.Clear();
                        book_textbox_genre.Clear();
                        break;
                    }
                case 4:
                    {
                        textbook_textbox_name.Clear();
                        textbook_num_year.Value = 2014;
                        textbook_num_count.Value = 2014;
                        textbook_num_count.Value = 1;
                        textbook_textbox_subject.Clear();
                        break;
                    }
            }
        }

        private void PrintViewError(object sender, EventArgs e)
        {
            MessageBox.Show("Ошибка! Пожалуйста, введите КОРРЕКТНЫЕ значения!");
        }
        private void JournalViewError(object sender, EventArgs e)
        {
            MessageBox.Show("Ошибка! Пожалуйста, введите КОРРЕКТНЫЕ значения!");
        }
        private void BookViewError(object sender, EventArgs e)
        {
            MessageBox.Show("Ошибка! Пожалуйста, введите КОРРЕКТНЫЕ значения!");
        }
        private void TextbookViewError(object sender, EventArgs e)
        {
            MessageBox.Show("Ошибка! Пожалуйста, введите КОРРЕКТНЫЕ значения!");
        }

        
    }
}

