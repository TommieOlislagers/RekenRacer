using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows;

namespace RekenRacer
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "rekenenwoordenracer";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<RekenenVragen> HaalAlleVragenOp()
        {
            // Vragen worden nu willekeurig geordend en maximaal 10 vragen
            string query = "SELECT * FROM reken_vragen AS v INNER JOIN reken_antwoorden AS a ON v.vraagId  = a.vraagId ORDER BY RAND() LIMIT 10";

            List<RekenenVragen> LijstVanVragen = new List<RekenenVragen>();

            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                using (var r = dataReader)
                {
                    foreach (DbDataRecord s in r)
                    {
                        LijstVanVragen.Add(new RekenenVragen((int)s["vraagId"], (string)s["vraag"], (string)s["antwoord"]));
                    }
                }

                dataReader.Close();

                this.CloseConnection();

                return LijstVanVragen;
            }
            else
            {
                return LijstVanVragen;
            }
        }

        public bool Login(string Gebruikersnaam, string Wachtwoord)
        {
            int counter = 0;
            string query = "SELECT * FROM gebruikers WHERE gebruikersnaam = '" + Gebruikersnaam + "' AND wachtwoord = '" + Wachtwoord + "';";


            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                using (var r = dataReader)
                {
                    foreach (DbDataRecord s in r)
                    {
                        counter++;
                    }
                }

                dataReader.Close();

                this.CloseConnection();

                if (counter > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Registeren(string Gebruikersnaam, string Wachtwoord)
        {
            string query = "INSERT INTO gebruikers (gebruikersnaam, wachtwoord) VALUES ('" + Gebruikersnaam + "', '" + Wachtwoord + "');";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int haalGebruikerIdOpPerGebruikersnaam(string gebruikersnaam)
        {
            int id = 0;
            string query = "SELECT gebruikerId FROM gebruikers WHERE gebruikersnaam = '" + gebruikersnaam + "';";


            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                using (var r = dataReader)
                {
                    foreach (DbDataRecord s in r)
                    {
                        id = (int)s["gebruikerId"];
                    }
                }

                dataReader.Close();

                this.CloseConnection();

            }
            return id;
        }

        public bool HighScoreToevoegen(string Gebruikersnaam, int score)
        {
            string query = "INSERT INTO highscores (score, gebruikerId, datum, tijd) VALUES ('" + score + "', '" + haalGebruikerIdOpPerGebruikersnaam(Gebruikersnaam) + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "');";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public List<HighscoreClass> haalAlleHighscoresOp()
        {
            string query = "SELECT * FROM highscores INNER JOIN gebruikers ON highscores.gebruikerId = gebruikers.gebruikerId ORDER BY highscores.score";

            List<HighscoreClass> LijstVanHighscores = new List<HighscoreClass>();

            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                using (var r = dataReader)
                {
                    foreach (DbDataRecord s in r)
                    {
                        string[] datumZonderTijd = s["datum"].ToString().Split(' ');
                        LijstVanHighscores.Add(new HighscoreClass((string)s["gebruikersnaam"], (int)s["gebruikerId"], (int)s["score"], datumZonderTijd[0], s["tijd"].ToString())); ;
                    }
                }

                dataReader.Close();

                this.CloseConnection();
            }
            return LijstVanHighscores;
        }

    }
}
