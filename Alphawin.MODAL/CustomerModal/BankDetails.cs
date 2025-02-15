using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphawin.MODAL.CustomerModal
{
    public class BankDetailsAdd
    {
        public string CustomerId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }

        public string ReenterAccount { get; set; }
    }

    public class BankDetailsView
    {
        public string CustomerId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string ReenterAccount { get; set; }
        public string CustomerName { get; set; }
        public string ReferalCode { get; set; }
    }

    public class BankDetailsViewResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public BankDetailsView CDS { get; set; }
    }

    public class BankDetailsAddResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public BankDetailsAdd CDS { get; set; }
    }

}
