using Alphawin.MODAL.CustomerModal;
using Alphawin.BLL.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Http;
using System.Web;

namespace Alpha.API.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [Route("getOTP")]
        [HttpPost]
        public CustomerOTPResponse OTPGenerate(CustomerEmail cf)
        {
            return new Login().CheckLogin(cf.Email);
        } 
        [Route("UpdateProfile")]
        [HttpPost]
        public CustomerProfileUpdateResponse ProfileUpdate(ProfileUpdateFilter cf)
        {
            cf.ProfileImage = Base64ToImages(cf.ProfileImage);
            return new Login().UpdateProfile(cf);
        }
        [Route("UpdateMobile")]
        [HttpPost]
        public CustomerMobileUpdateResponse MobileUpdate(MobileUpdateFilter cf)
        {          
            return new Login().UpdateMobile(cf);
        }
        [Route("UpdateDetails")]
        [HttpPost]
        public CustomerDetailsUpdateResponse CustomerDetailsUpdate(CustomerDetailsUpdateFilter cf)
        {
            cf.ProfileImage = Base64ToImages(cf.ProfileImage);
            return new Login().UpdateCustomerDetails(cf);
        }
        [Route("getFullDetails")]
        [HttpGet]
        public CustomerDetailsViewResponse MobileUpdate(CustomerFilter cf)
        {
            return new Login().getCustomerDetails(cf);
        }
        private string Base64ToImages(string base64Strings)
        {

            string _filePth = "~/uploads/" + DateTime.Now.ToString("yyMMddhhmmss") + "_" + new Random().Next(1, 1000).ToString() + ".png";
            // Strip off the data:image/...;base64, part if included
            if (base64Strings.Contains(","))
            {
                base64Strings = base64Strings.Split(',')[1];
            }
            // Convert Base64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64Strings);

            // Convert byte[] to Image
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);

                // Save the image to the specified path
                image.Save(HttpContext.Current.Server.MapPath(@"" + _filePth), ImageFormat.Png); // Change the format if needed
            }
            return _filePth;
        }
    }
}