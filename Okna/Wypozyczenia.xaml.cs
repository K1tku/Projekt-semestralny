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
    /// Logika interakcji dla klasy Wypozyczenia.xaml
    /// </summary>
    /// 
    ////Łączenie z serverm i baza danych.
    //Wyswietlenie bazy danych w DataGrid.
    //Trzy przyciski kolejno od dodawania rekordów w bazie, usuwania oraz aktualizowania.
    public partial class Wypozyczenia : Window
    {   //łączenie z baza danych
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;

        //Ładowanie skompilowaną strone skladnika
        public Wypozyczenia()
        {
            InitializeComponent();
        }

        private void DataGridWy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DataGridWy_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {  //pobieranie danych z bazy i wyswietlenie w DataGrid
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_wypozyczenia, ID_Gry, ID_pracownika, ID_klienta, Data_wypozyczenia from dbo.Wypozyczenia";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridWy.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "insert into Wypozyczenia (ID_wypozyczenia, ID_Gry, ID_pracownika, ID_klienta, Data_wypozyczenia) values('" + this.iD_wypozyczeniaTextBox.Text + "','" + this.iD_GryTextBox.Text + "','" + this.iD_pracownikaTextBox.Text + "','" + this.iD_klientaTextBox.Text + "','" + this.iD_wypozyczeniaTextBox.Text + "');";
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
            string Query = "delete from Wypozyczenia where ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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
            string Query = "update Wypozyczenia set ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "',ID_Gry='" + this.iD_GryTextBox.Text + "',ID_pracownika='" + this.iD_pracownikaTextBox.Text + "',ID_klienta='" + this.iD_klientaTextBox.Text + "',ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "'where ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Uaktualniono");
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
            // Załaduj dane do tabeli Wypozyczenia. Możesz modyfikować ten kod w razie potrzeby.
            Projekt.Wypozyczalnia_Gier_komputerowychDataSetTableAdapters.WypozyczeniaTableAdapter wypozyczalnia_Gier_komputerowychDataSetWypozyczeniaTableAdapter = new Projekt.Wypozyczalnia_Gier_komputerowychDataSetTableAdapters.WypozyczeniaTableAdapter();
            wypozyczalnia_Gier_komputerowychDataSetWypozyczeniaTableAdapter.Fill(wypozyczalnia_Gier_komputerowychDataSet.Wypozyczenia);
            System.Windows.Data.CollectionViewSource wypozyczeniaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("wypozyczeniaViewSource")));
            wypozyczeniaViewSource.View.MoveCurrentToFirst();
        }
    }
}
