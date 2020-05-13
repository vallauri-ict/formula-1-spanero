using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Scores
    {
        private int id;
        private int score;
        private string detail;

        public Scores(int id)
        {
            this.Id = id;
        }

        public Scores( int score, string detail)
        {
            this.Score = score;
            this.Detail = detail;
        }

        public int Id { get => id; set => id = value; }
        public int Score { get => score; set => score = value; }
        public string Detail { get => detail; set => detail = value; }
    }
}
