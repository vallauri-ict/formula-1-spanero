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
    public class RacesController : ApiController
    {
        DbTools db = new DbTools();

        [Route("races")]
        [HttpGet]
        public IEnumerable<Race> GetAllRaces()
        {
            return db.Races.Values;
        }

        [Route("races/{id}")]
        [HttpGet]
        public IHttpActionResult GetRace(int id)
        {
            try
            {
                db.GetRaces();
                if (db.Races[id] == null)
                    return NotFound();

                return Ok(db.Races[id]);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
