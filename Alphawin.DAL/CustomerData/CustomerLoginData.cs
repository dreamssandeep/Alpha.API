using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphawin.DAL.CustomerData
{
    public class CustomerLoginData
    {
        #region usp_Add_Customer


        //usp_Add Employee

        public DataTable get_Customer(string CustomerId, string CustomerName, string ReferalCode, string CustomerEmail, string CustomerMobile,bool? IsActive)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
               new SqlParameter("@action", "get_Customer"),
               new SqlParameter("@CustomerId",CustomerId),
               new SqlParameter("@CustomerName",CustomerName),
               new SqlParameter("@ReferalCode",ReferalCode),
               new SqlParameter("@CustomerEmail",CustomerEmail),
               new SqlParameter("@CustomerMobile",CustomerMobile),           
               new SqlParameter("@IsActive", IsActive),

                };
            return SqlDBHelper.ExecuteParamerizedSelectCommand("[dbo].[usp_Add_Employee]", CommandType.StoredProcedure, parameter);
        }
        public DataTable Check_ReferalCodeExit(string ReferalCode)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
               new SqlParameter("@action", "Check_ReferalCodeExit"),
               new SqlParameter("@ReferalCode",ReferalCode),
              
                };
            return SqlDBHelper.ExecuteParamerizedSelectCommand("[dbo].[usp_Add_Employee]", CommandType.StoredProcedure, parameter);
        }
        public DataTable Check_CustomerEmailExit(string CustomerEmail)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
               new SqlParameter("@action", "Check_CustomerEmailExit"),
               new SqlParameter("@CustomerEmail",CustomerEmail),
              
                };
            return SqlDBHelper.ExecuteParamerizedSelectCommand("[dbo].[usp_Add_Employee]", CommandType.StoredProcedure, parameter);
        }
      

        public bool Add_Customer_Email(string CustomerId, string ReferalCode, string CustomerEmail)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
            new SqlParameter("@action","add_Add_Employee"),
            new SqlParameter("@CustomerId",CustomerId),
            new SqlParameter("@ReferalCode",ReferalCode),
            new SqlParameter("@CustomerEmail",CustomerEmail),
           

            };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_Customer]", CommandType.StoredProcedure, parameter);

        }

        public bool update_Customer_Profile(string ProfileImage, string CustomerId)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@action", "update_Customer_Profile"),
                new SqlParameter("@ProfileImage", ProfileImage),
                new SqlParameter("@CustomerId", CustomerId)
                };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_Customer]", CommandType.StoredProcedure, parameter);
        }
        public bool update_Customer_Name(string CustomerName,string CustomerMobile, string CustomerId)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@action", "update_Customer_Name"),
                new SqlParameter("@CustomerName", CustomerName),
                new SqlParameter("@CustomerMobile", CustomerMobile),
                new SqlParameter("@CustomerId", CustomerId)
                };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_Customer]", CommandType.StoredProcedure, parameter);
        }
        public bool update_Customer_Mobile(string CustomerName, string CustomerMobile, string CustomerId)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@action", "update_Customer_Mobile"),
                new SqlParameter("@CustomerName", CustomerName),
                new SqlParameter("@CustomerMobile", CustomerMobile),
                new SqlParameter("@CustomerId", CustomerId)
                };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_Customer]", CommandType.StoredProcedure, parameter);
        }

        public bool delete_Customer(string EmplyeeId)
        {
            SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@action", "delete_Customer"),
                new SqlParameter("@EmplyeeId", EmplyeeId)
                };
            return SqlDBHelper.ExecuteNonQuery("[dbo].[usp_Customer]", CommandType.StoredProcedure, parameter);
        }

        #endregion
    }
}
