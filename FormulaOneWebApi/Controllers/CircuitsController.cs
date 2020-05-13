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
    public class CircuitsController : ApiController
    {
        DbTools db = new DbTools();

        [Route("circuits")]
        [HttpGet]
        public IEnumerable<Circuits> GetAllCircuits()
        {
            return db.Circuits.Values;
        }

        [Route("circuits/{id}")]
        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            try
            {
                db.GetCircuits();
                if (db.Circuits[id] == null)
                    return NotFound();

                return Ok(db.Circuits[id]);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
