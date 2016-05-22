using StockProductivityCalculation.Models;
using System.Net.Http;
using System.Web.Http;

namespace StockProductivityCalculation.Controllers
{
    public class StockController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Calculate(StockDetails details)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}
