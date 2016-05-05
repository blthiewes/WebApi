using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestfulApi.Application.Interfaces;
using RestfulApi.ServiceModel;
using RestfulApi.ServiceModel.RequestMessages;
using RestfulApi.ServiceModel.ResponseMessages;

namespace RestfulApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/customer/{partyNumberOrCode}/bolComment")]
        [HttpGet]
        public HttpResponseMessage GetCustomerBOLComment(string partyNumberOrCode)
        {
            string bolComment = _customerService.GetBOLComment(partyNumberOrCode);

            return Request.CreateResponse(HttpStatusCode.OK, new { bolComment });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partyCode"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Route("api/customer/{partyCode}/onlineContact")]
        [HttpGet]
        public HttpResponseMessage GetOnlineContact(string partyCode, string userName)
        {
            var request = new GetOnlineContactRequest
            {
                PartyCode = partyCode,
                UserName = userName
            };

            Contact contact = _customerService.GetOnlineContact(request);

            if (contact == null)
                return null;

            var response = new GetOnlineContactResponse
            {
                PhoneNumber = contact.PhoneNumber,
                EmailAddress = contact.EmailAddress,
                Name = contact.Name,
                PartyID = contact.PartyID
            };

            return response.Errors != null && response.Errors.Any()
                ? Request.CreateResponse(HttpStatusCode.NotFound, response)
                : Request.CreateResponse(response);
        }
    }
}