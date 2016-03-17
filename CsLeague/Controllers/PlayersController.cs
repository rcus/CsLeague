using System.Net;
using System.Net.Http;
using System.Web.Http;
using CsLeague.Models;

namespace CsLeague.Controllers
{
    public class PlayersController : ApiController
    {
        private CsLeagueContext db = new CsLeagueContext();

        [AcceptVerbs("PATCH")]
        public HttpResponseMessage Patch(int id, Players obj)
        {
            System.Diagnostics.Debug.WriteLine(obj);
            var p = db.Players.Find(id);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            p.Score = obj.Score;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}