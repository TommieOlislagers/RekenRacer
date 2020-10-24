namespace RekenRacer
{
    public class HighscoreClass
    {
        private int _idHighscores;
        private int _score;
        private int _gebruikerId;
        private string _datum;
        private string _tijd;
        private string _gebruikersnaam;

        public string Gebruikersnaam
        {
            get { return _gebruikersnaam; }
            set { _gebruikersnaam = value; }
        }
        public string Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }
        public string Tijd
        {
            get { return _tijd; }
            set { _tijd = value; }
        }
        public int GebruikerId
        {
            get { return _gebruikerId; }
            set { _gebruikerId = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int HighscoreId
        {
            get { return _idHighscores; }
            set { _idHighscores = value; }
        }

        public HighscoreClass(int gebruikerId, int score, string datum, string tijd)
        {
            this.GebruikerId = gebruikerId;
            this.Score = score;
            this.Datum = datum;
            this.Tijd = tijd;
        }

        public HighscoreClass(string gebruikersnaam, int gebruikerId, int score, string datum, string tijd)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.GebruikerId = gebruikerId;
            this.Score = score;
            this.Datum = datum;
            this.Tijd = tijd;
        }
    }
}
