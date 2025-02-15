using Alphawin.MODAL.CustomerModal;
using Alphawin.BLL.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Alpha.API.Controllers
{
    [RoutePrefix("api/LoginOTP")]
    public class LoginController : ApiController
    {
        [Route("get")]
        [HttpPost]
        public CustomerOTPResponse OTPGenerate(CustomerEmail cf)
        {
            return new Alphawin.BLL.Customer.Login().CheckLogin(cf.Email);
        }
    }
}