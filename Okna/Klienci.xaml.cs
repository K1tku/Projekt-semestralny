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
    /// 

    //Łączenie z serverm i baza danych.
    //Wyswietlenie bazy danych w DataGrid.
    //Trzy przyciski kolejno od dodawania rekordów w bazie, usuwania oraz aktualizowania.
    public partial class Klienci : Window
    {

        //łączenie z baza danych
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;

        ////Ładowanie skompilowana strone składnika
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
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "insert into Klienci (ID_klienta, Nazwisko, Imie, Adres, Kod_pocztowy, Data_urodzenia, Numer_DO) values('" + this.iD_klientaTextBox.Text + "','" + this.nazwiskoTextBox.Text + "','" + this.imieTextBox.Text + "','" + this.adresTextBox.Text + "','" + this.kod_pocztowyTextBox.Text + "','" + this.data_urodzeniaDatePicker + "','" + this.numer_DOTextBox.Text + "');";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Zapisano");
                while (myReader.Read()) { }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

       

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "delete from Klienci  where ID_klienta='" + this.iD_klientaTextBox.Text + "';";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Zapisano");
                while (myReader.Read()) { }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void uaktualnij_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "update Klienci set ID_klienta='" + this.iD_klientaTextBox.Text + "',Nazwisko='" + this.nazwiskoTextBox.Text + "',Imie='" + this.imieTextBox.Text + "',Adres='" + this.adresTextBox.Text + "',Kod_pocztowy='" + this.kod_pocztowyTextBox.Text + "',Data_urodzenia='" + this.data_urodzeniaDatePicker + "',Numer_DO='" + this.numer_DOTextBox.Text + "' where ID_klienta='" + this.iD_klientaTextBox.Text + "';";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Uaktualnione");
                while (myReader.Read()) { }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Projekt.Wypozyczalnia_Gier_komputerowychDataSet wypozyczalnia_Gier_komputerowychDataSet = ((Projekt.Wypozyczalnia_Gier_komputerowychDataSet)(this.FindResource("wypozyczalnia_Gier_komputerowychDataSet")));
            // Załaduj dane do tabeli Klienci. Możesz modyfikować ten kod w razie potrzeby.
            Projekt.Wypozyczalnia_Gier_komputerowychDataSetTableAdapters.KlienciTableAdapter wypozyczalnia_Gier_komputerowychDataSetKlienciTableAdapter = new Projekt.Wypozyczalnia_Gier_komputerowychDataSetTableAdapters.KlienciTableAdapter();
            wypozyczalnia_Gier_komputerowychDataSetKlienciTableAdapter.Fill(wypozyczalnia_Gier_komputerowychDataSet.Klienci);
            System.Windows.Data.CollectionViewSource klienciViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("klienciViewSource")));
            klienciViewSource.View.MoveCurrentToFirst();
        }
    }
}
