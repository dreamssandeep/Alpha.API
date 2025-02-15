using Alphawin.DAL.CustomerData;
using Alphawin.MODAL.CustomerModal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphawin.BLL.Customer
{
    public class BankDetails
    {
        public BankDetailsAddResponse AddBankDetails(BankDetailsAdd cf)
        {
            BankDetailsAddResponse ur = new BankDetailsAddResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Customer required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.AccountNo))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Account No required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.AccountHolderName))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Account Holder Name required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.BankName))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Bank Name required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.IFSC))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "IFSC required.";
                return ur;
            }

            BankDetailsAdd ud = new BankDetailsAdd();
            if (new BankDetailsData().Add_BankDetails(null,cf.CustomerId, cf.BankName,cf.IFSC,cf.AccountNo,cf.ReenterAccount,cf.AccountHolderName))
            {
                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Bank Details Submit Successfully";
               
            }
            else
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Some Error Occur.";
               
            }

            return ur;
        }

        public BankDetailsViewResponse getBankDetails(CustomerFilter cf)
        {
            BankDetailsViewResponse ur = new BankDetailsViewResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "CustomerId required.";
                return ur;
            }



            DataTable dtm = new BankDetailsData().get_BankDetails(null,cf.CustomerId, null);
            if (dtm.Rows.Count > 0)
            {
                BankDetailsView ud = new BankDetailsView();
                ud.CustomerId = dtm.Rows[0]["CustomerId"].ToString();
                ud.CustomerName = dtm.Rows[0]["CustomerName"].ToString();
                ud.BankName = dtm.Rows[0]["BankName"].ToString();
                ud.ReferalCode = dtm.Rows[0]["ReferalCode"].ToString();
                ud.AccountNo = dtm.Rows[0]["AccountNo"].ToString();
                ud.IFSC = dtm.Rows[0]["IFSC"].ToString();
                ud.ReenterAccount = dtm.Rows[0]["ReenterAccount"].ToString();
                ud.AccountHolderName = dtm.Rows[0]["AccountHolderName"].ToString();

                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Bank Details Fatch Successfully";
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

        public BankDetailsAddResponse UpdateBankDetails(BankDetailsAdd cf)
        {
            BankDetailsAddResponse ur = new BankDetailsAddResponse();
            if (string.IsNullOrEmpty(cf.CustomerId))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Customer required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.BankName))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Bank Name required.";
                return ur;
            } 
            if (string.IsNullOrEmpty(cf.AccountHolderName))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Account Holder required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.AccountNo))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "Account No required.";
                return ur;
            }
            if (string.IsNullOrEmpty(cf.IFSC))
            {
                ur.status = "Failed";
                ur.StatusCode = 0;
                ur.statusText = "IFSC required.";
                return ur;
            }

            BankDetailsAdd ud = new BankDetailsAdd();
            if (new BankDetailsData().update_Customer_BankDetails(cf.CustomerId,cf.BankName, cf.IFSC,cf.AccountNo,cf.ReenterAccount,cf.AccountHolderName))
            {
                ur.status = "Success";
                ur.StatusCode = 1;
                ur.statusText = "Bank Details Update Successfully";
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
    }
}
