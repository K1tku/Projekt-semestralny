using System;
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
    /// Logika interakcji dla klasy Gry.xaml
    /// </summary>
    public partial class Gry : Window
    {
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;
        public Gry()
        {
            InitializeComponent();
            
        }


        private void DataGridGry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
        private void DataGridGry_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_gry, Nazwa, Kategoria, Kategoria_wiekowa, Data_wydania, Cena_dzien from dbo.Gry";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridGry.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        
    }
}
