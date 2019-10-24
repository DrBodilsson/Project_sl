﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Models;
using Library.Services;

namespace Library
{
    public partial class AddBookCopyForm : Form
    {
        BookCopyService BCS;
        Book selectedBook;

        public AddBookCopyForm(Book book, BookCopyService bookCopyService)
        {
            BCS = bookCopyService;
            selectedBook = book;
            InitializeComponent();
        }

        private void btn_AddBookCopy_Click(object sender, EventArgs e)
        {
            if (cb_Condition.SelectedItem == null)
            {
                MessageBox.Show("Please choose a number from the list.");
            }
            else
            {
                string selectedCondition = cb_Condition.SelectedItem.ToString();
                int condition;
                if (int.TryParse(selectedCondition, out condition))
                {
                    BookCopy bookCopy = new BookCopy()
                    {
                        Book = selectedBook,
                        Condition = condition
                    };
                    BCS.Add(bookCopy);
                }
            }  
        }

        private void AddBookCopyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
