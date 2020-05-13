using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class RacesScores
    {
        private int id;
        private string driver;
        private int score;
        private string race;
        private string fastestLap;

        public RacesScores()
        {
        }

        public RacesScores(int id)
        {
            this.Id = id;
        }

        public RacesScores(string driver, int score, string race, string fastestLap)
        {
            this.Driver = driver;
            this.Score = score;
            this.Race = race;
            this.FastestLap = fastestLap;
        }

        public int Id { get => id; set => id = value; }
        public string Driver { get => driver; set => driver = value; }
        public int Score { get => score; set => score = value; }
        public string Race { get => race; set => race = value; }
        public string FastestLap { get => fastestLap; set => fastestLap = value; }
    }
}
