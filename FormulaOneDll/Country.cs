using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Country
    {
        #region Attributes
        private string countryCode;
        private string countryName;
        private string flag;
        #endregion

        #region Constructors
        public Country() { }

        public Country(string countryCode, string countryName, string flag)
        {
            this.CountryCode = countryCode;
            this.CountryName = countryName;
            this.Flag = flag;
        }
        #endregion

        #region Properties
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string CountryName { get => countryName; set => countryName = value; }
        public string Flag { get => flag; set => flag = value; }
        #endregion

        #region Methods
        public override string ToString() => $"{this.CountryCode} {this.CountryName}";
        #endregion
    }
}
