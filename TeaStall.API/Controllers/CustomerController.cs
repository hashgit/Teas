using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeaStall.Business.Models;
using TeaStall.Database.Models;
using TeaStall.Services.Models;

namespace TeaStall.API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerBusiness _customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [HttpPost]
        [ActionName("Customer")]
        public HttpResponseMessage AddCustomer(CustomerDto dto)
        {
            try
            {
                if (dto == null)
                    throw new ArgumentNullException("dto");

                bool result;
                if (!string.IsNullOrWhiteSpace(dto.Id))
                    result = _customerBusiness.UpdateCustomer(new Customer()
                    {
                        Id = dto.Id,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        DoB = dto.DoB
                    });
                else
                {
                    var customer = new Customer {FirstName = dto.FirstName, LastName = dto.LastName, DoB = dto.DoB };
                    result = _customerBusiness.AddCustomer(customer);
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

        [HttpGet]
        [ActionName("Customer")]
        public HttpResponseMessage GetCustomers()
        {
            try
            {
                var customers = _customerBusiness.GetCustomers();
                return Request.CreateResponse(HttpStatusCode.OK, customers.Select(c => new CustomerDto()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DoB = c.DoB
                }));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to process request.", e);
            }
        }

    }
}
