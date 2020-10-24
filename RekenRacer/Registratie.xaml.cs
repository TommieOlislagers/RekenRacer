using System.Windows;

namespace RekenRacer
{
    /// <summary>
    /// Interaction logic for Registratie.xaml
    /// </summary>
    public partial class Registratie : Window
    {
        public Registratie()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (wachtwoord.Text.Length == 0)
            {
                MessageBox.Show("Voer een wachtwoord in.");
            }
            else if (wachtwoordVerificatie.Password.Length == 0)
            {
                MessageBox.Show("Voer een verificatie wachtwoord in.");
            }
            else if (wachtwoord.Text != wachtwoordVerificatie.Password)
            {
                MessageBox.Show("Het wachtwoord moet gelijk zijn aan het verificatie wachtwoord.");
            }
            else
            {
                string gebruikersnaam = gebruikersNaam.Text;
                string wachtwoord = wachtwoordVerificatie.Password;
                bool Registeren = new DBConnect().Registeren(gebruikersnaam, wachtwoord);

                if (Registeren)
                {
                    Login login = new Login();
                    login.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met het registeren.");
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}
