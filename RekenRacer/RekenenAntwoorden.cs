namespace RekenRacer
{
    public class RekenenAntwoorden
    {
        private int _antwoordId;
        private string _antwoord;

        public string Antwoord
        {
            get { return _antwoord; }
            set { _antwoord = value; }
        }

        public int AntwoordID
        {
            get { return _antwoordId; }
            set { _antwoordId = value; }
        }

        public RekenenAntwoorden(string antwoord, int antwoordId)
        {
            this.AntwoordID = antwoordId;
            this.Antwoord = antwoord;
        }
    }
}
