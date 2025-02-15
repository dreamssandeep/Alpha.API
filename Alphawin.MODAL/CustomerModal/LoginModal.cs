using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphawin.MODAL.CustomerModal
{
    public class CustomerFilter
    {
        public string CustomerId { get; set; }
    }
    public class CustomerEmail
    {
        public string Email { get; set; }
    }

    public class CustomerOTP
    {
        public string CustomerId { get; set; }
        public string OTP {  get; set; }
        public string CustomerEmail { get; set; }
        public string OTPTime { get; set; }
        public string ReferalCode { get; set; }
    }

    public class CustomerProfileUpdate
    {
        public string CustomerId { get; set; }
        public string ProfileImage { get; set; }
    }

    public class CustomerNameMobile
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
    }

    public class CustomerOTPResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerOTP CDS { get; set; }
    }
    public class CustomerProfileUpdateResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerProfileUpdate CDS { get; set; }
    }
    public class CustomerNameMobileResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerNameMobile CDS { get; set; }
    }
}
