using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeaStall.Business.Models;
using TeaStall.Services.Models;

namespace TeaStall.API.Controllers
{
    public class TeaContentsController : ApiController
    {
        private readonly ITeaStallBusiness _teaStallBusiness;

        public TeaContentsController(ITeaStallBusiness teaStallBusiness)
        {
            _teaStallBusiness = teaStallBusiness;
        }

        [HttpPost]
        [ActionName("TeaBase")]
        public HttpResponseMessage AddTeaBase(string teaBase)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(teaBase))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "parameter teaBase cannot be null");

                _teaStallBusiness.AddTeaBase(teaBase);
                return this.Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpGet]
        [ActionName("TeaBase")]
        public HttpResponseMessage GetTeaBase()
        {
            try
            {
                var baseTeas = _teaStallBusiness.GetTeaBase();
                return this.Request.CreateResponse(HttpStatusCode.OK, baseTeas.Select(b => new TeaBaseDto { Id = b.Id, Base = b.BaseTea, Price = b.Price}));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpPut]
        [ActionName("TeaBasePrice")]
        public HttpResponseMessage SetTeaBasePrice(string baseId, double price)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(baseId))
                    throw new ArgumentNullException("baseId");

                return this.Request.CreateResponse(HttpStatusCode.OK, _teaStallBusiness.SetBasePrice(baseId, price));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpPost]
        [ActionName("Flavor")]
        public HttpResponseMessage AddFlavor(string flavor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(flavor))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "parameter flavor cannot be null");

                _teaStallBusiness.AddFlavor(flavor);
                return this.Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpGet]
        [ActionName("Flavor")]
        public HttpResponseMessage GetFlavors()
        {
            try
            {
                var flavors = _teaStallBusiness.GetFlavors();
                return this.Request.CreateResponse(HttpStatusCode.OK, flavors.Select(b => new FlavorDto { Id = b.Id, Flavor = b.Flavor, Price = b.Price }));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpPut]
        [ActionName("FlavorPrice")]
        public HttpResponseMessage SetFlavorPrice(string flavorId, double price)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(flavorId))
                    throw new ArgumentNullException("flavorId");

                return this.Request.CreateResponse(HttpStatusCode.OK, _teaStallBusiness.SetFlavorPrice(flavorId, price));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpPost]
        [ActionName("Topping")]
        public HttpResponseMessage AddTopping(string topping)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(topping))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "parameter topping cannot be null");

                _teaStallBusiness.AddTopping(topping);
                return this.Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpGet]
        [ActionName("Topping")]
        public HttpResponseMessage GetToppings()
        {
            try
            {
                var toppings = _teaStallBusiness.GetToppings();
                return this.Request.CreateResponse(HttpStatusCode.OK, toppings.Select(b => new ToppingDto { Id = b.Id, Topping = b.Topping, Price = b.Price }));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpPut]
        [ActionName("ToppingPrice")]
        public HttpResponseMessage SetToppingPrice(string toppingId, double price)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toppingId))
                    throw new ArgumentNullException("toppingId");

                return this.Request.CreateResponse(HttpStatusCode.OK, _teaStallBusiness.SetToppingPrice(toppingId, price));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }
    }
}
