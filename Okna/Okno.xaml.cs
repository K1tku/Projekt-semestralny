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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Okno.xaml
    /// </summary>
     
    //Łaczymy sie z baza danych i za pomaca przycisków prznosimy sie do poszczególnych okien.
    //
    public partial class Okno : Window
    {   //łączenie z baza danych
        private const String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        private SqlConnection connection;

        //Ładowanie skompilowana strone składnika
        public Okno()
        {
            InitializeComponent();

        }

        private void Prac_Click(object sender, RoutedEventArgs e)
        {

            connection = new SqlConnection(connection_String);

            try
            {   //otwarcie połączenia
                connection.Open();
                var w = Application.Current.Windows[1];
                w.Hide();
                //przejscie do kolejnego okna
                Okna.Pracownicy signIn = new Okna.Pracownicy();
                signIn.ShowDialog();
                w.Show();
            }
            catch (SqlException)
            {
                MessageBox.Show("Błąd");
            }
            connection.Close();


        }

        private void Gry_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connection_String);

            try
            {
                connection.Open();
                var w = Application.Current.Windows[1];
                w.Hide();
                
                Okna.Gry signIn = new Okna.Gry();
                signIn.ShowDialog();
                w.Show();
            }
            catch (SqlException)
            {
                MessageBox.Show("Błąd");
            }
            connection.Close();


        }

        private void Klie_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connection_String);

            try
            {
                connection.Open();
                var w = Application.Current.Windows[1];
                w.Hide();
                
                Okna.Klienci signIn = new Okna.Klienci();
                signIn.ShowDialog();
                w.Show();
            }
            catch (SqlException)
            {
                MessageBox.Show("Błąd");
            }
            connection.Close();


        }

        private void Wypo_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connection_String);

            try
            {
                connection.Open();
                var w = Application.Current.Windows[1];
                w.Hide();
                
                Okna.Wypozyczenia signIn = new Okna.Wypozyczenia();
                signIn.ShowDialog();
                w.Show();
            }
            catch (SqlException) { 
           
                MessageBox.Show("Błąd");
            }
            connection.Close();


        }

        private void Zwro_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connection_String);

            try
            {
                connection.Open();
                var w = Application.Current.Windows[1];
                w.Hide();
                
                Okna.Zwroty signIn = new Okna.Zwroty();
                signIn.ShowDialog();
                w.Show();
            }
            catch (SqlException)
            {
                MessageBox.Show("Błąd");
            }
            connection.Close();


        }


    


    }
}

