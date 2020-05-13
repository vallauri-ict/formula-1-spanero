using FormulaOneDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormulaOneWebApi.Controllers
{
    public class CircuitsController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Circuits> GetAllCircuits()
        {
            return db.Circuits.Values;
        }

        public IHttpActionResult GetCountry(int id)
        {
            return NotFound();
        }
    }
}
