﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Driver
    {
        #region Attributes
        private readonly int id;
        private int number;
        private string firstname;
        private string lastname;
        private DateTime dob;
        private string placeOfBirthday;
        private string image;
        private Country country;
        #endregion

        #region Constructors
        public Driver(int id) { this.id = id; }

        public Driver(int id, int number ,string firstname, string lastname, DateTime dob, string placeOfBirthday, string image, Country country) : this (id)
        {
            this.Number = number;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Dob = dob;
            this.PlaceOfBirthday = placeOfBirthday;
            this.Image = image;
            this.Country = country;
        }
        #endregion

        #region Properties
        public int ID { get => id; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string PlaceOfBirthday { get => placeOfBirthday; set => placeOfBirthday = value; }
        public Country Country { get => country; set => country = value; }
        public string Image { get => image; set => image = value; }
        public int Number { get => number; set => number = value; }
        #endregion

        #region Methods
        public override string ToString() => $"{this.Firstname} {this.lastname}";
        #endregion
    }
}
