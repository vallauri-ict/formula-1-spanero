using FormulaOneDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormulaOneWebApi.Controllers
{
    [RoutePrefix("api")]
    public class CountriesController : ApiController
    {
        DbTools db = new DbTools();

        [Route("countries")]
        [HttpGet]
        public IEnumerable<Country> GetAllCountries()
        {
            return db.Countries.Values;
        }

        [Route("countries/{id}")]
        [HttpGet]
        public IHttpActionResult GetCountry(string id)
        {
            try
            {
                db.GetCountries();
                if (db.Countries[id] == null)
                    return NotFound();

                return Ok(db.Countries[id]);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
