using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphawin.DAL
{
    public class SqlDBHelper
    {
        const string CONNECTION_STRING = @"Data Source=103.211.202.68;DATABASE=admin_awapi;user id=awsandip; password=2^d7a5Fu5;Timeout=20000;Min Pool Size=0;Max Pool Size=100;Pooling=true;";

        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] parameter)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return table;
        }
        // This function will be used to execute R(CRUD) operation of parameterized commands
        internal static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch (Exception es)
                    {
                        throw es;
                    }
                }
            }

            return table;
        }
        internal static DataSet ExecuteParamerizedSelectCommandds(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return ds;
        }
        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        public static bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;
            SqlTransaction trans;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }
                trans = con.BeginTransaction();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        trans.Dispose();
                        con.Close();
                    }
                }
            }

            return (result > 0);
        }
        internal static int ExecuteNonQueryParamIntTemp(string CommandName, CommandType cmdType, SqlParameter[] pars, int parano)
        {
            int result = 0;
            SqlTransaction trans;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }
                trans = con.BeginTransaction();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    pars[parano].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddRange(pars);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            result = Convert.ToInt32(cmd.Parameters["@returnId"].Value.ToString());
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        trans.Dispose();
                        con.Close();
                    }
                }
            }

            return result;
        }
        internal static int ExecuteNonQueries(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;
            SqlTransaction trans;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }
                trans = con.BeginTransaction();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {


                        result = cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        trans.Dispose();
                        con.Close();
                    }
                }
            }
            return (result);
        }
    }
}
