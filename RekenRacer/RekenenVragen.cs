namespace RekenRacer
{
    public class RekenenVragen
    {
        private int _vraagId;
        private string _vraag;
        private string _antwoord;

        public string Antwoord
        {
            get { return _antwoord; }
            set { _antwoord = value; }
        }
        public string Vraag
        {
            get { return _vraag; }
            set { _vraag = value; }
        }

        public int VraagID
        {
            get { return _vraagId; }
            set { _vraagId = value; }
        }

        public RekenenVragen(int vraagId, string vraag, string antwoord)
        {
            this.VraagID = vraagId;
            this.Vraag = vraag;
            this.Antwoord = antwoord;
        }
    }
}
