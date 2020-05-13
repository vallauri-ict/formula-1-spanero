using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Circuits
    {
        private int id;
        private string name;
        private string city;
        private int length;
        private string recordLap;
        private string img;
        private int firstGrandPrix;

        public Circuits(int id, string name, string city, int length, string recordLap, string img, int firstGrandPrix)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
            this.Length = length;
            this.RecordLap = recordLap;
            this.Img = img;
            this.FirstGrandPrix = firstGrandPrix;
        }

        public Circuits(int id) { this.Id = id; }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public int Length { get => length; set => length = value; }
        public string RecordLap { get => recordLap; set => recordLap = value; }
        public string Img { get => img; set => img = value; }
        public int FirstGrandPrix { get => firstGrandPrix; set => firstGrandPrix = value; }
    }
}
