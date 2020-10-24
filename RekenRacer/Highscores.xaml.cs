using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace RekenRacer
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>

    public partial class Highscores : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Deze functie moet worden aangeroepen zodra de waarde van een van de "properties"
        /// van deze "class" is veranderd. Deze functie roept dan de "PropertyChanged" event
        /// handler aan welke ervoor zorgt dat de layout en bijbehorende Binding bijgewerkt wordt.
        /// </summary>
        /// <param name="propertyName">De naam van de gewijzigde property</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _gebruiker;

        public string Gebruiker
        {
            get { return _gebruiker; }
            set { _gebruiker = value; }
        }

        private List<HighscoreClass> _highscores;
        public List<HighscoreClass> HighscoreLijst
        {
            get { return _highscores; }
            set { _highscores = value; NotifyPropertyChanged(); }
        }

        public Highscores()
        {
            InitializeComponent();
            HighscoreLijst = new DBConnect().haalAlleHighscoresOp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HoofdMenu hm = new HoofdMenu();
            hm.lblGebruiker.Content = Gebruiker;
            hm.Show();
            Close();
        }
    }
}
