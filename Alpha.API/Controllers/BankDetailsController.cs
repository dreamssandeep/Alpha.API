using Alphawin.BLL.Customer;
using Alphawin.MODAL.CustomerModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Alpha.API.Controllers
{
    [RoutePrefix("api/BankDetails")]
    public class BankDetailsController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public BankDetailsAddResponse AddBank(BankDetailsAdd cf)
        {
            return new BankDetails().AddBankDetails(cf);
        }
        
        [Route("Update")]
        [HttpPost]
        public BankDetailsAddResponse UpdateBank(BankDetailsAdd cf)
        {
            return new BankDetails().UpdateBankDetails(cf);
        }
        [Route("get")]
        [HttpGet]
        public BankDetailsViewResponse GetBank(CustomerFilter cf)
        {
            return new BankDetails().getBankDetails(cf);
        }
    }
}