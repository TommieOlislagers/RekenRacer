using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RekenRacer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        private int _raceCarPositionCol;
        private int _waardeAntwoord1;
        private int _waardeAntwoord2;
        private int _waardeAntwoord3;
        private int _levens;
        private int _score;
        private string _vraag;
        private List<RekenenVragen> _rekenenVragen;
        private int _vraagIndex;
        private int _antwoordIndex;
        private int _antwoord;
        private static Random _randomAntwoord = new Random((int)DateTime.Now.Ticks);

        public Random RndAntwoord
        {
            get { return _randomAntwoord; }
            set { _randomAntwoord = value; }
        }

        public int Antwoord
        {
            get { return _antwoord; }
            set { _antwoord = value; }
        }

        public int AntwoordIndex
        {
            get { return _antwoordIndex; }
            set { _antwoordIndex = value; }
        }

        public List<RekenenVragen> RekenenVragen
        {
            get { return _rekenenVragen; }
            set { _rekenenVragen = value; }
        }

        public int raceCarPositionColumn
        {
            get { return _raceCarPositionCol; }
            set { _raceCarPositionCol = value; NotifyPropertyChanged(); }
        }

        public int Antwoord1
        {
            get { return _waardeAntwoord1; }
            set { _waardeAntwoord1 = value; NotifyPropertyChanged(); }
        }

        public int Antwoord2
        {
            get { return _waardeAntwoord2; }
            set { _waardeAntwoord2 = value; NotifyPropertyChanged(); }
        }

        public int Antwoord3
        {
            get { return _waardeAntwoord3; }
            set { _waardeAntwoord3 = value; NotifyPropertyChanged(); }
        }

        public int Levens
        {
            get { return _levens; }
            set { _levens = value; NotifyPropertyChanged(); }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; NotifyPropertyChanged(); }
        }

        public string Vraag
        {
            get { return _vraag; }
            set { _vraag = value; NotifyPropertyChanged(); }
        }

        public int VraagIndex
        {
            get { return _vraagIndex; }
            set { _vraagIndex = value; NotifyPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();

            // Maak de uitleg zienbaar na het moment dat de window is geinitialiseerd, hierdoor zijn de andere elementen nog wel zichtbaar in de xaml designer
            rtUitleg.Visibility = Visibility.Visible;
            Levens = 3;
            Score = 0;

            lblLevens.Content = "Levens: " + Levens.ToString();
            lblScore.Content = "Score: " + Score.ToString();

            VraagIndex = -1;

            RekenenVragen = new DBConnect().HaalAlleVragenOp();
            VerdeelAntwoorden();
        }


        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            // Wanneer de uitleg over is mogen de pijltjes toetsen pas gebruikt worden
            if (e.Key == Key.Space)
            {
                rtUitleg.Visibility = Visibility.Hidden;
            }

            if (rtUitleg.Visibility == Visibility.Hidden)
            {

                if (e.Key == Key.Left)
                {
                    // Dit zorgt ervoor dat de auto geen niet bestaande kolom pakt voor links
                    if (raceCarPositionColumn > 0)
                    {
                        raceCarPositionColumn -= 1;
                        this.raceCar.SetValue(Grid.ColumnProperty, raceCarPositionColumn);
                    }

                }

                if (e.Key == Key.Right)
                {
                    // Dit zorgt ervoor dat de auto geen niet bestaande kolom pakt voor rechts
                    if (raceCarPositionColumn < 2)
                    {
                        raceCarPositionColumn += 1;
                        this.raceCar.SetValue(Grid.ColumnProperty, raceCarPositionColumn);
                    }
                }

                if (e.Key == Key.Enter)
                {

                    if (raceCarPositionColumn == AntwoordIndex)
                    {
                        Score += 50;
                        lblScore.Content = "Score: " + Score.ToString();
                        MessageBox.Show("Dat klopt! Je hebt nog " + Levens + " levens.");
                    }
                    else
                    {
                        Levens--;
                        lblLevens.Content = "Levens: " + Levens.ToString();

                        if (Levens != 0)
                        {
                            MessageBox.Show("Dat is helaas fout :( Je hebt nog " + Levens + " levens.");
                        }
                    }

                    VerdeelAntwoorden();

                }
            }

            if (Levens == 0)
            {
                MessageBoxResult result = MessageBox.Show("Je hebt geen levens meer. Game over. Eindscore: " + Score + "\n Wilt u uw eindscore opslaan in de highscore lijst?", "Eindbericht", MessageBoxButton.YesNo);
                HighScoreBericht(result);
            }

        }

        public void HighScoreBericht(MessageBoxResult result)
        {
            switch (result)
            {
                case MessageBoxResult.Yes:
                    bool HighscoreToevoegen = new DBConnect().HighScoreToevoegen(lblGebruiker.Content.ToString(), Score);

                    if (HighscoreToevoegen)
                    {
                        MessageBox.Show("Highscore is succesvol toegevoegd!");
                    }
                    else
                    {
                        MessageBox.Show("Er is iets misgegaan met het toevoegen van de highscore.");
                    }

                    OpenHetHoofdMenu();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Bedankt voor het spelen!", "Bedankscherm");
                    System.Windows.Application.Current.Shutdown();
                    break;
            }
        }

        public void OpenHetHoofdMenu()
        {
            HoofdMenu hm = new HoofdMenu();
            hm.lblGebruiker.Content = lblGebruiker.Content;
            hm.Show();
            Close();
        }

        public void VerdeelAntwoorden()
        {
            if (VraagIndex != RekenenVragen.Count - 1)
            {
                VraagIndex++;
                Vraag = "Hoeveel is " + RekenenVragen[VraagIndex].Vraag.ToString() + " ?";

                int kiesEenRandomAntwoord = new Random().Next(0, 100);
                Antwoord = int.Parse(RekenenVragen[VraagIndex].Antwoord);

                // Dit kan zeker weten verbeterd worden, voor nu alleen geen vereiste
                if (kiesEenRandomAntwoord <= 34)
                {
                    Antwoord1 = Antwoord;
                    Antwoord2 = RandomAntwoorden(Antwoord);

                    Antwoord3 = RandomAntwoorden(Antwoord);

                    while (Antwoord3 == Antwoord2)
                    {
                        Antwoord3 = RandomAntwoorden(Antwoord);
                    }

                    AntwoordIndex = 0;
                }
                else if (kiesEenRandomAntwoord <= 67)
                {
                    Antwoord1 = RandomAntwoorden(Antwoord);
                    Antwoord2 = Antwoord;
                    Antwoord3 = RandomAntwoorden(Antwoord);

                    while (Antwoord3 == Antwoord1)
                    {
                        Antwoord3 = RandomAntwoorden(Antwoord);
                    }

                    AntwoordIndex = 1;
                }
                else if (kiesEenRandomAntwoord <= 100)
                {
                    Antwoord1 = RandomAntwoorden(Antwoord);
                    Antwoord2 = RandomAntwoorden(Antwoord);
                    Antwoord3 = Antwoord;

                    while (Antwoord2 == Antwoord1)
                    {
                        Antwoord2 = RandomAntwoorden(Antwoord);
                    }

                    AntwoordIndex = 2;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Je hebt alle 10 de vragen beantwoord. Eindscore: " + Score + "\n Wilt u uw eindscore opslaan in de highscore lijst?", "Eindbericht", MessageBoxButton.YesNo);
                HighScoreBericht(result);
            }

        }

        public static Random randomErbijOfEraf = new Random((int)DateTime.Now.Ticks);

        public int RandomAntwoorden(int Antwoord)
        {
            int RandomAntwoord = Antwoord;

            if (RndAntwoord.Next(0, 100) > 50)
            {
                // Dit zorgt ervoor dat het nieuwe random (foute) antwoord niet hetzelfde is als het goede antwoord
                while (RandomAntwoord == Antwoord)
                {
                    RandomAntwoord = Antwoord - randomErbijOfEraf.Next(0, 10);
                }
            }
            else
            {
                while (RandomAntwoord == Antwoord)
                {
                    RandomAntwoord = Antwoord + randomErbijOfEraf.Next(0, 10);
                }

            }

            return RandomAntwoord;
        }
    }
}
