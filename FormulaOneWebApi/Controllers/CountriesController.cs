using FormulaOneDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormulaOneWebApi.Controllers
{
    public class CountriesController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Country> GetAllDrivers()
        {
            return db.Countries.Values;
        }

        public IHttpActionResult GetCountry(int id)
        {
            return NotFound();
        }
    }
}
