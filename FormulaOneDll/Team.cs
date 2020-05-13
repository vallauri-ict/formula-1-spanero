using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    [DataContract]
    public class Team
    {
        #region Attributes
        private int id;
        private string logo;
        private string name;
        private string fullTeamName;
        private Country country;
        private string powerUnit;
        private string technicalChief;
        private string chassis;
        private Driver firstDriver;
        private Driver secondDriver;
        #endregion

        #region Constructors
        public Team() { }

        public Team(int id, string logo, string nome, string fullTeamName, Country country, string powerUnit, string technicalChief, string chassis, Driver firstDriver, Driver secondDriver)
        {
            this.ID = id;
            this.Logo = logo;
            this.Name = nome;
            this.FullTeamName = fullTeamName;
            this.Country = country;
            this.PowerUnit = powerUnit;
            this.TechnicalChief = technicalChief;
            this.Chassis = chassis;
            this.FirstDriver = firstDriver;
            this.SecondDriver = secondDriver;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ID { get => id; set => id = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string FullTeamName { get => fullTeamName; set => fullTeamName = value; }
        
        public Country Country { get => country; set => country = value; }
        [DataMember]
        public string PowerUnit { get => powerUnit; set => powerUnit = value; }
        [DataMember]
        public string TechnicalChief { get => technicalChief; set => technicalChief = value; }
        [DataMember]
        public string Chassis { get => chassis; set => chassis = value; }
       
        public Driver FirstDriver { get => firstDriver; set => firstDriver = value; }
        
        public Driver SecondDriver { get => secondDriver; set => secondDriver = value; }
        [DataMember]
        public string Logo { get => logo; set => logo = value; }
        #endregion

        #region Methods
        public override string ToString() => $"{this.Name} ({this.Country.CountryName})";
        #endregion
    }
}
