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
    /// Logika interakcji dla klasy Klienci.xaml
    /// </summary>
    public partial class Klienci : Window
    {

        //łączenie z baza danych
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;
        public Klienci()
        {
            InitializeComponent();
        }

        private void DataGridKli_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }

        private void DataGridKli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void updateDataGrid()
        {
            //pobieranie danych z bazy i wyswietlenie w DataGrid
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            //zapytanie "Select"
            cmd.CommandText = "SELECT ID_klienta, Nazwisko, Imie, Adres, Kod_pocztowy, Data_urodzenia, Numer_DO from dbo.Klienci";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridKli.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void zapisz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
