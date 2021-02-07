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
//using System.Windows.Forms;

namespace Projekt.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy Gry.xaml
    /// </summary>
    /// 
    //Pobieranie danych z servera bazy.
    //Wyświetlenie zawartości bazy w DataGrid.
    //Pierwszy przycisk dodaje dane do bazy, drugi usuwa dane a trzeci aktualizuje po ID.
    public partial class Gry : Window
    {  //łącznie z baza danych
        public String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
        public SqlConnection connection;
        ////Ładowanie skompilowana strone składnika
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
            //pobieranie danych z bazy i wyswietlenie w DataGrid
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
        //Przycisk dodania do wiersza do bazy danych
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "insert into Gry (ID_gry, Nazwa, Kategoria, Kategoria_wiekowa, Data_wydania, Cena_dzien) values('" + this.iD_gryTextBox.Text + "','" + this.nazwaTextBox.Text + "','" + this.kategoriaTextBox.Text + "','" + this.kategoria_wiekowaTextBox.Text + "','" + this.data_wydaniaTextBox.Text + "','" + this.cena_dzienTextBox.Text + "');";
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
            updateDataGrid();
            
            }
     
        
        //Przycisk do usunięcia wiersza o danym ID_gry z bazy danych
        private void usun_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "delete from Gry where ID_gry='" + this.iD_gryTextBox.Text + "';";
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
            updateDataGrid();


        }
        //Przycisk zakutalizowania wiersza bazy danych
        private void uaktualnij_Click(object sender, RoutedEventArgs e)
        {
            String connection_String = "Data Source = LAPTOP-VSA1L11T; Initial Catalog = Wypozyczalnia_Gier_komputerowych;USER ID=user;PASSWORD=user";
            string Query = "update Gry set ID_gry='" + this.iD_gryTextBox.Text + "', Nazwa='" + this.nazwaTextBox.Text + "',Kategoria='" + this.kategoriaTextBox.Text + "',Kategoria_wiekowa='" + this.kategoria_wiekowaTextBox.Text + "',Data_wydania='" + this.data_wydaniaTextBox.Text + "',Cena_dzien='" + this.cena_dzienTextBox.Text + "'where ID_gry='" + this.iD_gryTextBox.Text + "'; ";
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
            updateDataGrid();

        }
    }
}
