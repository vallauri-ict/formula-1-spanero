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
    public class RacesScoresController : ApiController
    {
        DbTools db = new DbTools();
        private List<RacesScores> racesSelected;


        [Route("racesScores")]
        [HttpGet]
        public IEnumerable<RacesScores> GetAllRacesScores()
        {
            return db.RacesScores.Values;
        }

        [Route("racesScores/{id}")]
        [HttpGet]
        public IHttpActionResult GetRaceScores(int id)
        {
            try
            {
                db.GetRacesScores();
                
                RacesScores rs = new RacesScores();
                rs.Race = db.races[id].Circuit;
                if (db.RacesScores.ContainsValue(rs) == true)
                    return NotFound();

                racesSelected = new List<RacesScores>();
                foreach (var item in db.RacesScores)
                {
                    if(item.Value.Race== db.races[id].Circuit)
                    {
                        racesSelected.Add(item.Value);
                    }
                }
                return Ok(racesSelected);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
