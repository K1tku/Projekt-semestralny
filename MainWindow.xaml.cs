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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pobierzDane();
            
        }
        
        public void pobierzDane()
        {
            //pobierz dane logowania z formularza i przypisz
            string mojePolaczenie =
                "SERVER=" + Nservera.Text + ";" +
                "DATABASE=" + NazwaDB.Text + ";" +
                "UID=" + Nużytkownika.Text + ";" +
                "PASSWORD=" + Hużytkownika.Password + ";";

            SqlConnection polaczenie = new SqlConnection(mojePolaczenie);

            try
            {
                polaczenie.Open();

                var w = Application.Current.Windows[0];
                w.Hide();

                Okno signIn = new Okno();
                signIn.ShowDialog();

                //var Okno = new Okno();
                //Okno.ShowDialog();

                
                
            }
            catch (SqlException )
            {
                MessageBox.Show("Błąd logowania");
            }
            polaczenie.Close();
            

        }
    }
}
