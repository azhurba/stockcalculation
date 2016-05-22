using StockProductivityCalculation.Models;
using System.Collections;
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
            if(details.Price < 0)
            {
                ModelState.AddModelError("Price", string.Format("The value {0} is not valid for the field Price", details.Price));
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest,
                    ModelState);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}
