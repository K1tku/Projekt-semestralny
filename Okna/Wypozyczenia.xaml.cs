﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace Projekt.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy Wypozyczenia.xaml
    /// </summary>
    public partial class Wypozyczenia : Window
    {
        public Wypozyczenia()
        {
            InitializeComponent();
        }

        private void DataGridWy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
