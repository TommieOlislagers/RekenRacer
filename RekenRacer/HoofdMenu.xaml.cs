using System.Windows;

namespace RekenRacer
{
    /// <summary>
    /// Interaction logic for HoofdMenu.xaml
    /// </summary>
    public partial class HoofdMenu : Window
    {
        public HoofdMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Highscores hs = new Highscores();
            hs.Gebruiker = lblGebruiker.Content.ToString();
            hs.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.lblGebruiker.Content = lblGebruiker.Content;
            mw.Show();
            Close();
        }
    }
}
