using System.Windows;

namespace RekenRacer
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Registratie registratie = new Registratie();
            registratie.Show();
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string gebruikersnaam = tbGebruikersnaam.Text;
            string wachtwoord = tbWachtwoord.Password;

            bool Inloggen = new DBConnect().Login(gebruikersnaam, wachtwoord);

            if (Inloggen)
            {
                HoofdMenu hm = new HoofdMenu();
                hm.lblGebruiker.Content = gebruikersnaam;
                hm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Kon de combinatie van gebruiker en wachtwoord niet vinden.");
            }
        }
    }
}
