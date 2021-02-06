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
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    /// 
    //Łączenie z serverm i baza danych.
    //Wyswietlenie bazy danych w DataGrid.
    //Trzy przyciski kolejno od dodawania rekordów w bazie, usuwania oraz aktualizowania.
    public partial class Pracownicy : Window
    {   //łącznie z baza danych
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;
        
//ładowanie skompilowana strone skadnika
        public Pracownicy()
        {
            InitializeComponent();
        }

        private void DataGridPrac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        
        }

        private void DataGridPrac_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {   //pobieranie danych z bazy i wyswietlenie w DataGrid
            connection = new SqlConnection(connection_String);connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_pracownika,Imie, Nazwisko, Data_urodzenia, Adres, Stanowisko from dbo.Pracownicy";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridPrac.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "insert into Pracownicy (ID_pracownika, Imie, Nazwisko, Data_urodzenia, Adres, Stanowisko) values('" + this.iD_pracownikaTextBox.Text + "','" + this.imieTextBox.Text + "','" + this.nazwiskoTextBox.Text + "','" + this.data_urodzeniaDatePicker.Text + "','" + this.adresTextBox.Text + "','" + this.stanowiskoTextBox.Text + "');";
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
            string Query = "delete from Pracownicy where ID_pracownika='" + this.iD_pracownikaTextBox.Text + "';";
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
            string Query = "update Pracownicy set ID_pracownika='" + this.iD_pracownikaTextBox.Text + "',Imie='" + this.imieTextBox.Text + "',Nazwisko='" + this.nazwiskoTextBox.Text + "',Data_urodzenia='" + this.data_urodzeniaDatePicker.Text + "',Adres='" + this.adresTextBox.Text + "',Stanowisko='" + this.stanowiskoTextBox.Text + "' where ID_pracownika='" + this.iD_pracownikaTextBox.Text + "';";
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

        private void Pracownicy1_Loaded(object sender, RoutedEventArgs e)
        {

            Projekt.Wypozyczalnia_Gier_komputerowychDataSet wypozyczalnia_Gier_komputerowychDataSet = ((Projekt.Wypozyczalnia_Gier_komputerowychDataSet)(this.FindResource("wypozyczalnia_Gier_komputerowychDataSet")));
            // Załaduj dane do tabeli Pracownicy. Możesz modyfikować ten kod w razie potrzeby.
            Projekt.Wypozyczalnia_Gier_komputerowychDataSetTableAdapters.PracownicyTableAdapter wypozyczalnia_Gier_komputerowychDataSetPracownicyTableAdapter = new Projekt.Wypozyczalnia_Gier_komputerowychDataSetTableAdapters.PracownicyTableAdapter();
            wypozyczalnia_Gier_komputerowychDataSetPracownicyTableAdapter.Fill(wypozyczalnia_Gier_komputerowychDataSet.Pracownicy);
            System.Windows.Data.CollectionViewSource pracownicyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pracownicyViewSource")));
            pracownicyViewSource.View.MoveCurrentToFirst();
        }
    }
}

  
