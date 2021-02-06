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
    /// Logika interakcji dla klasy Zwroty.xaml
    /// </summary>
    /// 
    ////Łączenie z serverm i baza danych.
    //Wyswietlenie bazy danych w DataGrid.
    //Trzy przyciski kolejno od dodawania rekordów w bazie, usuwania oraz aktualizowania.
    public partial class Zwroty : Window
    {   //łączenie z baza danych
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;

        //ŁAdowanie skopilowana strone skladnika
        public Zwroty()
        {
            InitializeComponent();
        }

        private void DataGridZwroty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGridZwroty_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {  //pobieranie danych z bazy i wyswietlenie w DataGrid
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            //zapytanie sql
            cmd.CommandText = "SELECT ID_wypozyczenia, ID_pracownika, data_zwrotu, doplaty from dbo.Zwroty";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridZwroty.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "insert into Zwroty (ID_wypozyczenia, ID_pracownika, data_zwrotu, doplaty) values('" + this.iD_wypozyczeniaTextBox.Text + "','" + this.iD_pracownikaTextBox.Text + "','" + this.data_zwrotuDatePicker.Text + "','" + this.doplatyTextBox.Text + "' );";
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
            string Query = "delete from Zwroty  where ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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
            string Query = "update Zwroty set ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "',ID_pracownika='" + this.iD_pracownikaTextBox.Text + "',data_zwrotu='" + this.data_zwrotuDatePicker.Text + "',doplaty='" + this.doplatyTextBox.Text + "' whereID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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
    }
}
