using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        localhost.WebService server = new localhost.WebService();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            print_view.DataSource = server.Show_Print();
            journal_view.DataSource = server.Show_Journal();
            book_view.DataSource = server.Show_Book();
            textbook_view.DataSource = server.Show_Textbook();
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            server.Add_Print(print_textbox_name.Text, (int)print_num_year.Value, (int)print_num_count.Value);
            print_view.DataSource = server.Show_Print();
            Refresh(1);
        }

        private void journal_button_Click(object sender, EventArgs e)
        {
            server.Add_Journal(journal_textbox_name.Text, (int)journal_num_year.Value, (int)journal_num_count.Value, journal_textbox_periodicity.Text, journal_textbox_subjects.Text);
            journal_view.DataSource = server.Show_Journal();
            Refresh(2);
        }

        private void book_button_Click(object sender, EventArgs e)
        {
            server.Add_Book(book_textbox_name.Text, (int)book_num_year.Value, (int)book_num_count.Value, book_textbox_author.Text, book_textbox_genre.Text);
            book_view.DataSource = server.Show_Book();
            Refresh(3);
        }

        private void textbook_button_Click(object sender, EventArgs e)
        {
           server.Add_Textbook(textbook_textbox_name.Text, (int)textbook_num_year.Value, (int)textbook_num_count.Value, textbook_textbox_subject.Text);
           textbook_view.DataSource = server.Show_Textbook();
           Refresh(4);
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

        private void button2_Click(object sender, EventArgs e)
        {
            server.ClearTabs();
        }

        
    }
}
