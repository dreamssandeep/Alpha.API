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

    public class ProfileUpdateFilter
    {
        public string CustomerId { get; set; }
        public string ProfileImage {  get; set; }
    } 
    public class MobileUpdateFilter
    {
        public string CustomerId { get; set; }
        public string CustomerMobile {  get; set; }
    } 
    public class NameUpdateFilter
    {
        public string CustomerId { get; set; }
        public string CustomerName {  get; set; }
    } 
    public class CustomerDetailsUpdateFilter
    {
        public string CustomerId { get; set; }
        public string CustomerMobile {  get; set; }
        public string CustomerEmail {  get; set; }
        public string ProfileImage {  get; set; }
    }

    public class CustomerOTP
    {
        public string CustomerId { get; set; }
        public string OTP {  get; set; }
        public string CustomerEmail { get; set; }
        public string OTPTime { get; set; }
        public string ReferalCode { get; set; }
    }

    public class CustomerDetailsView
    {
        public string CustomerId { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string ProfileImage { get; set; }
        public string CustomerName { get; set; }
        public string ReferalCode { get; set; }
        public string DateOfJoining { get; set; }
    }

    public class CustomerDetailsUpdate
    {
        public string CustomerId { get; set; }
        public string CustomerMobile { get;set; }
        public string CustomerEmail { get; set; }
        public string ProfileImage { get; set; }
    }


    public class CustomerProfileUpdate
    {
        public string CustomerId { get; set; }
        public string ProfileImage { get; set; }
    }

    public class CustomerMobileUpdate
    {
        public string CustomerId { get; set; }
        public string CustomerMobile {  get; set; }
    } 
    public class CustomerNameUpdate
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
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
    public class CustomerMobileUpdateResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerMobileUpdate CDS { get; set; }
    }
    public class CustomerNameUpdateResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerNameUpdate CDS { get; set; }
    }
    public class CustomerDetailsUpdateResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerDetailsUpdate CDS { get; set; }
    } 
    public class CustomerDetailsViewResponse
    {
        public int StatusCode { get; set; }
        public string status { get; set; }
        public string statusText { get; set; }
        public CustomerDetailsView CDS { get; set; }
    }
}
