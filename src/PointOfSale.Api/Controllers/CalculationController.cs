using PointOfSale.BusinessLogic;
using PointOfSale.Core.Validators;
using PointOfSale.Data.Entities;
using PointOfSale.DataAccess;
using PointOfSale.DataAccess.Mocks;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PointOfSale.Api.Controllers
{
    public class CalculationController : ApiController
    {
        //This fields should be initialized by dependency injection
        private Terminal Terminal = new Terminal();
        private IRepository<ProductPrice> ProductPriceRepository = new ProductPriceRepositoryMock();

        [HttpGet]
        public HttpResponseMessage CalculateProductsCost(string productCodes)
        {
            var pricing = ProductPriceRepository.GetAll();

            var validationResult = ProductCodesValidator.Validate(productCodes, pricing);
            if (!validationResult.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, validationResult.Message);

            Terminal.SetPricing(pricing);

            foreach (var produtCode in productCodes.ToCharArray())
                Terminal.Scan(produtCode);

            return Request.CreateResponse(HttpStatusCode.OK, Terminal.CalculateTotal());
        }
    }
}
