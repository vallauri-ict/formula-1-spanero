using Microsoft.SqlServer.Diagnostics.STrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Race
    {
        private int id;
        private string gpName;
        private string circuit;
        private int nLaps;
        private DateTime gpDate;
        private string extCountry;

        public Race(int id)
        {
            this.Id = id;
        }

        public Race(string gpName, string circuit, int nLaps, DateTime gpDate, string extCountry)
        {
            this.GpName = gpName;
            this.Circuit = circuit;
            this.NLaps = nLaps;
            this.GpDate = gpDate;
            this.ExtCountry = extCountry;
        }

        public int Id { get => id; set => id = value; }
        public string GpName { get => gpName; set => gpName = value; }
        public string Circuit { get => circuit; set => circuit = value; }
        public int NLaps { get => nLaps; set => nLaps = value; }
        public DateTime GpDate { get => gpDate; set => gpDate = value; }
        public string ExtCountry { get => extCountry; set => extCountry = value; }
    }
}
