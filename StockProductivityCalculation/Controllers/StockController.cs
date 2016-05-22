using StockProductivityCalculation.Models;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;

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
            //Need to encode string before save
            details.Name = HttpUtility.HtmlEncode(details.Name);
            
            var result = StockCalculator.Calculate(new StockData(details));
            var repository = new StockHttpApplicationRepository(HttpContext.Current.Application);
            repository.Add(new StockCalculationResult(details, result));
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }

        [HttpGet]
        public List<StockCalculationResult> GetAllCalculations()
        {
            var repository = new StockHttpApplicationRepository(HttpContext.Current.Application);
            var result = repository.GetAll();
            return result == null ? null : result.ToList();
        }
    }
}
