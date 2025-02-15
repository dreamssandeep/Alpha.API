using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphawin.DAL.CustomerData
{
    public class BankDetailsData
    {
        #region usp_Add_BankDetails


        //usp_Add Employee

        public DataTable get_BankDetails(string BankDetailsId, string CustomerId, bool? IsActive)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
               new SqlParameter("@action", "get_BankDetails"),
               new SqlParameter("@CustomerId",CustomerId),
               new SqlParameter("@BankDetailsId",BankDetailsId),
               new SqlParameter("@IsActive", IsActive),

                };
            return SqlDBHelper.ExecuteParamerizedSelectCommand("[dbo].[usp_BankDetails]", CommandType.StoredProcedure, parameter);
        }
       
        public bool Add_BankDetails(string BankDetailsId, string CustomerId, string BankName,string IFSC,string AccountNo,string ReenteerAccountNo,string AccountHolderName)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
            new SqlParameter("@action","Add_BankDetails"),
            new SqlParameter("@BankDetailsId",BankDetailsId),
            new SqlParameter("@CustomerId",CustomerId),
            new SqlParameter("@BankName",BankName),
            new SqlParameter("@IFSC",IFSC),
            new SqlParameter("@AccountNo",AccountNo),
            new SqlParameter("@ReenteerAccountNo",ReenteerAccountNo),
            new SqlParameter("@AccountHolderName",AccountHolderName),
            };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_BankDetails]", CommandType.StoredProcedure, parameter);

        }
        public bool update_Customer_BankDetails(string CustomerId, string BankName, string IFSC, string AccountNo,string ReenteerAccountNo,string AccountHolderName)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
            new SqlParameter("@action","update_Customer_BankDetails"),
            new SqlParameter("@CustomerId",CustomerId),
            new SqlParameter("@BankName",BankName),
            new SqlParameter("@IFSC",IFSC),
            new SqlParameter("@AccountNo",AccountNo),
            new SqlParameter("@ReenteerAccountNo",ReenteerAccountNo),
            new SqlParameter("@AccountHolderName",AccountHolderName),
            };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_BankDetails]", CommandType.StoredProcedure, parameter);

        }


        public bool delete_BankDetails(string CustomerId)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@action", "delete_BankDetails"),
                new SqlParameter("@CustomerId", CustomerId)
                };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_BankDetails]", CommandType.StoredProcedure, parameter);
        }

        #endregion
    }
}
