using Alphawin.MODAL.CustomerModal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Alphawin.DAL.CustomerData;

namespace Alphawin.BLL.Customer
{
    public class Login
    {
        public CustomerOTPResponse CheckLogin(string Email)
        {
            CustomerOTPResponse ur = new CustomerOTPResponse();
            if (string.IsNullOrEmpty(Email))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Email required.";
                return ur;
            }

            CustomerOTP ud = new CustomerOTP();
            
            string OTP = new Random().Next(1, 9999).ToString("D4");           
            if(sendSignInOtp(Email, OTP))
            {
                string Referal = null;
                DataTable dt = new CustomerLoginData().Check_CustomerEmailExit(Email);
                if(dt.Rows.Count > 0)
                {
                    string CustomerId = dt.Rows[0]["CustomerId"].ToString();
                    DataTable dtm = new CustomerLoginData().get_Customer(CustomerId, null, null, null, null, null);
                    if(dtm.Rows.Count > 0)
                    {
                        Referal = dtm.Rows[0]["ReferalCode"].ToString();
                    }
                }
                else
                {
                    Referal = generateMemberCode();
                    new CustomerLoginData().Add_Customer_Email(null, Referal, Email);
                }
                ud.CustomerEmail = Email;
                ud.OTP = OTP;
                ud.OTPTime = DateTime.Now.ToString();
                ud.ReferalCode = Referal;
                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "OTP Generate.";
                ur.CDS = ud;
            }
            else
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Email not Correct.";
                ur.CDS = ud;
            }

            return ur;
        }

        public CustomerProfileUpdateResponse UpdateProfile(ProfileUpdateFilter cf)
        {
            CustomerProfileUpdateResponse ur = new CustomerProfileUpdateResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Customer required.";
                return ur;
            } 
            if (string.IsNullOrEmpty(cf.ProfileImage))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Profile Image required.";
                return ur;
            }

            CustomerProfileUpdate ud = new CustomerProfileUpdate();
            if (new CustomerLoginData().update_Customer_Profile(cf.ProfileImage, cf.CustomerId))
            {
                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Profile Update Successfully";
                ur.CDS = ud;
            }
            else
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Some Error Occur.";
                ur.CDS = ud;
            }

            return ur;
        }

        public CustomerMobileUpdateResponse UpdateMobile(MobileUpdateFilter cf)
        {
            CustomerMobileUpdateResponse ur = new CustomerMobileUpdateResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "CustomerId required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.CustomerMobile))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Mobile required.";
                return ur;
            }

            CustomerMobileUpdate ud = new CustomerMobileUpdate();
            if (new CustomerLoginData().update_Customer_Mobile(cf.CustomerMobile, cf.CustomerId))
            {
                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Mobile Update Successfully";
                ur.CDS = ud;
            }
            else
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Some Error Occur.";
                ur.CDS = ud;
            }

            return ur;
        }       
        public CustomerDetailsUpdateResponse UpdateCustomerDetails(CustomerDetailsUpdateFilter cf)
        {
            CustomerDetailsUpdateResponse ur = new CustomerDetailsUpdateResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "CustomerId required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.CustomerMobile))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Mobile required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.CustomerEmail))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Email required.";
                return ur;
            } if (string.IsNullOrEmpty(cf.ProfileImage))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Profile Image required.";
                return ur;
            }

            CustomerDetailsUpdate ud = new CustomerDetailsUpdate();
            if (new CustomerLoginData().update_Customer_Details(cf.CustomerId,cf.CustomerMobile,cf.ProfileImage,cf.CustomerEmail))
            {
                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Details Update Successfully";
                ur.CDS = ud;
            }
            else
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Some Error Occur.";
                ur.CDS = ud;
            }

            return ur;
        }

        public CustomerDetailsViewResponse getCustomerDetails(CustomerFilter cf)
        {
            CustomerDetailsViewResponse ur = new CustomerDetailsViewResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "CustomerId required.";
                return ur;
            }



            DataTable dtm = new CustomerLoginData().get_Customer(cf.CustomerId,null,null,null,null,null);
            if (dtm.Rows.Count > 0)
            {
                CustomerDetailsView ud = new CustomerDetailsView();
                ud.CustomerId = dtm.Rows[0]["CustomerId"].ToString();
                ud.CustomerName = dtm.Rows[0]["CustomerName"].ToString();
                ud.CustomerEmail = dtm.Rows[0]["CustomerEmail"].ToString();
                ud.ReferalCode = dtm.Rows[0]["ReferalCode"].ToString();
                ud.DateOfJoining = dtm.Rows[0]["DateOfJoining"].ToString();
                ud.ProfileImage = dtm.Rows[0]["ProfileImage"].ToString().Replace("~/", "https://aw.dizitaldreams.in/");

                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Details Fatch Successfully";
                ur.CDS = ud;
            }
            else
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Some Error Occur.";
               
            }

            return ur;
        }
        private bool forwardMailss(string email, string Subject, string sbodyHtml)
        {
           
            try
            {
                MailMessage mailMessage = new MailMessage(new MailAddress("contact@dizitaldreams.in "), new MailAddress(email));
               // mailMessage.Bcc.Add("dreamsdizital@gmail.com");
                // mailMessage.Bcc.Add("dizitaldreams1098@gmail.com");
                mailMessage.Subject = Subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = sbodyHtml.ToString();
                NetworkCredential networkCredentials = new NetworkCredential("contact@dizitaldreams.in ", "oekffzatynpcyrcz");
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 999999;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredentials;
                // smtpClient.Host = "smtp.zoho.in";  
                smtpClient.Port = 587;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool sendSignInOtp(string email, string OTP)
        {
            //string msg = "OTP from onebharatlive.com " + OTP + "";
            //forwardSMS(mobile, "1007162485800317282", msg);

            string Subject = "Alphawin OTP";
            StringBuilder sbodyHtml = new StringBuilder();
            sbodyHtml.Append(@"<HTML><HEAD><TITLE>" + Subject + "</TITLE></HEAD><body>" +
                   "<table width='70%' border='0' cellspacing='0' cellpadding='0'>" +
                      "<tr><td><form name='frm_query' action='' method='post'><table width='100%' border='0' cellspacing='0' cellpadding='4'><tr>" +
                      "<td  valign='top' style='font-family:Arial, Helvetica, sans-serif; color:#fff; font-size:10pt;' width='100'>" +
                        "<img src='	https://aw.dizitaldreams.in/Alpawins.png' width='180px' />" +
                      "</td><td valign='top' width='78%' ></td></tr>" +
                      "<tr><td colspan='3'><div width='700px'>" +
                          "<h4>Dear User</h4>" +
                          "<p>   Your OTP for SignIn with <a href=''>Alphawin</a> is <strong>" + OTP + "</strong> ." +
                          "Please feel free to contact us. </p>" +
                          "<h5>Regards,</h5><p><strong>Team Alphawin</strong></p></div>" +
                      "</tr></table></body></HTML>");
            forwardMailss(email, Subject, sbodyHtml.ToString());
            return true;
        }

        private String generateMemberCode()
        {
            string ReferalCode = "AW" + new Random().Next(1, 99999999).ToString("D7");
            DataTable dtMem = new CustomerLoginData().Check_ReferalCodeExit(ReferalCode);
            if (dtMem.Rows.Count != 0)
            {
                return generateMemberCode();
            }
            else
            {
                return ReferalCode;
            }
        }
    }
}
