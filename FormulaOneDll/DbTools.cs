using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.IO;

// Cercare questi pacchetti su nuget
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.ComponentModel;

using Newtonsoft.Json;

namespace FormulaOneDll
{
    public class DbTools
    {
        private const string WORKINGPATH = @"C:\Dati\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Dati\FormulaOne.mdf;Integrated Security=True";

        private Dictionary<int, Driver> drivers;
        private Dictionary<string, Country> countries;
        private Dictionary<int, Circuits> circuits;
        public Dictionary<int, Race> races;
        private Dictionary<int, RacesScores> racesScores;
        private Dictionary<int, Scores> scores;
        private List<Team> teams;

        public Dictionary<int, Driver> Drivers
        {
            get
            {
                if (this.drivers == null || this.drivers.Count == 0)
                    this.GetDrivers();
                return this.drivers;
            }
            set => drivers = value;
        }
        public Dictionary<string, Country> Countries
        {
            get
            {
                if (this.countries == null)
                    this.GetCountries();
                return this.countries;
            }
            set => countries = value;
        }
        public Dictionary<int, Circuits> Circuits
        {
            get
            {
                if (this.circuits == null)
                    this.GetCircuits();
                return this.circuits;
            }
            set => circuits = value;
        }
        public Dictionary<int, Race> Races
        {
            get
            {
                if (this.races == null)
                    this.GetRaces();
                return this.races;
            }
            set => races = value;
        }

        public Dictionary<int, RacesScores> RacesScores
        {
            get
            {
                if (this.racesScores == null)
                    this.GetRacesScores();
                return this.racesScores;
            }
            set => racesScores = value;
        }

        public Dictionary<int, Scores> Scores
        {
            get
            {
                if (this.scores == null)
                    this.GetScores();
                return this.scores;
            }
            set => scores = value;
        }

        public List<Team> Teams
        {
            get
            {
                if (teams == null || teams.Count == 0)
                    this.LoadTeams();
                return teams;
            }
            set => teams = value;
        }

        //public void CreateCountriesWithSmo()
        //{
        //    string sqlConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; 
        //        AttachDbFilename =C:\Users\loren\OneDrive\Desktop\_Scuola\2019-2020\INFORMATICA\CAMBIERI\FormulaOneSolution\FormulaOne.mdf; Integrated Security = True";
        //    FileInfo file = new FileInfo(@"Countries.sql");
        //    string script = file.OpenText().ReadToEnd();
        //    SqlConnection conn = new SqlConnection(sqlConnectionString);
        //    Server server = new Server(new ServerConnection(conn));

        //    try
        //    {
        //        server.ConnectionContext.ExecuteNonQuery(script);
        //        file.OpenText().Close();
        //        conn.Close();
        //        Console.WriteLine("CreateCountries: SUCCESS");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex);
        //    }
        //}

        public void ExecuteSqlScript(string sqlScriptPath)
        {
            var fileContent = File.ReadAllText($"{WORKINGPATH}{sqlScriptPath}");
            fileContent = fileContent
                .Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var sqlQueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            var cmd = new SqlCommand("query", con);
            con.Open();
            foreach (var query in sqlQueries)
            {
                cmd.CommandText = query;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Errore in esecuzione della query numero: {ex.LineNumber}");
                    Console.WriteLine($"Errore: {ex.Number} {ex.Message}");
                }
            }
            con.Close();
            con.Dispose();
            SqlConnection.ClearAllPools();
        }

        //public void MakeBackup()
        //{
        //    StreamReader sr = new StreamReader($"{WORKINGPATH}FormulaOne.mdf");
        //    StreamWriter sw = new StreamWriter($"{WORKINGPATH}FormulaOneBackup.mdf");
        //    sw.Write(sr.ReadToEnd());
        //    sr.Close();
        //    sw.Close();
        //}
        //public void Restore()
        //{
        //    StreamReader sr = new StreamReader($"{WORKINGPATH}FormulaOneBackup.mdf");
        //    StreamWriter sw = new StreamWriter($"{WORKINGPATH}FormulaOne.mdf");
        //    sw.Write(sr.ReadToEnd());
        //    sr.Close();
        //    sw.Close();
        //}

        //public void DropTable(string tableName)
        //{
        //    var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
        //    var cmd = new SqlCommand($"Drop Table {tableName};", con);
        //    con.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"Errore: {ex.Number} {ex.Message}");
        //    }
        //    con.Close();
        //    con.Dispose();
        //}

        public void GetCountries()
        {
            if (this.countries == null)
            {
                this.countries = new Dictionary<string, Country>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Countries;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string countryIsoCode = reader.GetString(0);
                        Country c = new Country()
                        {
                            CountryCode = countryIsoCode,
                            CountryName = reader.GetString(1),
                            Flag = reader.GetString(2)
                        };
                        this.countries.Add(countryIsoCode, c);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void GetCircuits()
        {
            if (this.circuits == null)
            {
                this.circuits = new Dictionary<int, Circuits>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Circuits;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int circuitsId = reader.GetInt32(0);                       
                        Circuits c = new Circuits(circuitsId)
                        {
                            Name = reader.GetString(1),
                            City = reader.GetString(2),
                            Length = reader.GetInt32(3),
                            RecordLap = reader.GetString(4),
                            Img = reader.GetString(5),
                            FirstGrandPrix = reader.GetInt32(6)
                        };
                        this.circuits.Add(circuitsId, c);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void GetRaces()
        {
            if (this.races == null)
            {
                this.races = new Dictionary<int, Race>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Races;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int raceId = reader.GetInt32(0);
                        Race c = new Race(raceId)
                        {
                            GpName = reader.GetString(1),
                            Circuit = Circuits[reader.GetInt32(2)].Name,
                            NLaps = reader.GetInt32(3),
                            GpDate = reader.GetDateTime(4),
                            ExtCountry = Countries[reader.GetString(5)].CountryName 
                        };
                        this.races.Add(raceId, c);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void GetScores()
        {
            if (this.scores == null)
            {
                this.scores = new Dictionary<int, Scores>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Scores;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int scoreId = reader.GetInt32(0);
                        Scores s = new Scores(scoreId)
                        {
                            Score = reader.GetInt32(1),
                            Detail = reader.GetString(2)
                        };
                        this.scores.Add(scoreId, s);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void GetRacesScores()
        {
            if (this.racesScores == null)
            {
                this.racesScores = new Dictionary<int, RacesScores>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Races_Scores;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int raceScoreId = reader.GetInt32(0);
                        RacesScores c = new RacesScores(raceScoreId)
                        {
                            Driver = Drivers[reader.GetInt32(1)].Firstname +" "+ Drivers[reader.GetInt32(1)].Lastname,
                            Score = Scores[reader.GetInt32(2)].Score,
                            Race = Races[reader.GetInt32(3)].Circuit,
                            FastestLap = reader.GetString(4)
                        };
                        this.racesScores.Add(raceScoreId, c);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void GetDrivers(bool forceReload = false)
        {
            if (forceReload/* || this.countries == null*/)
                this.GetCountries();
            if (forceReload || this.drivers == null)
            {
                this.Drivers = new Dictionary<int, Driver>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Drivers;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int driverIsoCode = reader.GetInt32(0);
                        Driver d = new Driver(driverIsoCode)
                        {
                            Number = reader.GetInt32(1),
                            Firstname = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Dob = reader.GetDateTime(4),
                            PlaceOfBirthday = reader.GetString(5),
                            Image = reader.GetString(6),
                            Country = Countries[reader.GetString(7)]
                        };
                        this.Drivers.Add(driverIsoCode, d);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void LoadTeams()
        {
            GetCountries();
            GetDrivers(true);
            teams = new List<Team>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            using (con)
            {
                con.Open();
                var command = new SqlCommand("SELECT * FROM Teams;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Team t = new Team()
                    {
                        ID = reader.GetInt32(0),
                        Logo = reader.GetString(1),
                        Name = reader.GetString(2),
                        FullTeamName = reader.GetString(3),
                        Country = this.Countries[reader.GetString(4)],
                        PowerUnit = reader.GetString(5),
                        TechnicalChief = reader.GetString(6),
                        Chassis = reader.GetString(7),
                        FirstDriver = this.Drivers[reader.GetInt32(8)],
                        SecondDriver = this.Drivers[reader.GetInt32(9)]
                    };
                    teams.Add(t);
                }
                con.Close();
                con.Dispose();
            }
            SqlConnection.ClearAllPools();
        }

        public bool SerializeToJSON<T>(IEnumerable<T> list, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                new StreamWriter(path, false).Write(json);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
