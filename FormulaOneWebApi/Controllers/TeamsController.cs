using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormulaOneDll;

namespace FormulaOneWebApi.Controllers
{
    [RoutePrefix("api")]
    public class TeamsController : ApiController
    {
        DbTools db = new DbTools();

        [Route("teams")]
        [HttpGet]
        public IEnumerable<Team> GetAllTeams()
        {
            return db.Teams;
        }

        [Route("teams/{id}")]
        [HttpGet]
        public IHttpActionResult GetTeam(int id)
        {
            try
            {
                db.LoadTeams();
                if (db.Teams[id] == null)
                    return NotFound();

                return Ok(db.Teams[id]);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
