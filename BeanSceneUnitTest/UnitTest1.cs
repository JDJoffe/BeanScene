using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Data;

using System.Data.Common;
using System.Configuration;
using System.Linq;
//using Microsoft.Extensions.Configuration;

namespace BeanSceneUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        SQLDAL dal = new SQLDAL();
        string _connection;
        SqlConnection conn = new SqlConnection();

        [TestMethod]
        public void CheckConnection()
        { 
            bool result = false;
            try
            {         
                _connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                conn.ConnectionString = _connection;

                conn.Open();
                if (!String.IsNullOrEmpty(conn.Database))
                {
                    result = true;
                    Console.WriteLine(conn.Database);
                    Console.WriteLine(_connection);
                }            
            }
            catch (Exception)
            {
                throw;
            }  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckRowUpdate()
        {
            bool result = false;
            int id = 1;
            int status = 3;
            try
            {
                _connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                conn.ConnectionString = _connection;

                dal._connection = _connection;
               
                 dal.ExecuteNonQuery($"UPDATE RESERVATION SET STATUS = {status} WHERE id = {id}");
                Console.WriteLine("Status = seated");
                      
                DataTable dt = dal.ExecuteSQL($"SELECT id FROM RESERVATION WHERE STATUS = {status} AND ID = {id}");
                if (dt.Rows.Count >= 1)
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        Console.WriteLine(dataRow[0]);
                    }
                    result = true;
                } 
                dal.ExecuteNonQuery($"UPDATE RESERVATION SET STATUS = {status+=1} WHERE id = {id}"); 
                Console.WriteLine("Status = completed");
            }
            catch (Exception)
            {
                throw;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCurrentSitting()
        {
            bool result = false;
            int sittingId = 0;
            try
            {
                _connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                conn.ConnectionString = _connection;

                dal._connection = _connection;
                SqlParameter[] sqlparams =
                {
                new SqlParameter("@TimeSlotId",SqlDbType.Int){ Value = DateTime.Now.Hour},
                new SqlParameter("Date", SqlDbType.DateTime2){Value = DateTime.Today.Date}
                };
                string sql = "USP_AssignSitting";
                DataTable dt = dal.ExecuteSQL(sql, sqlparams, true);
                foreach (DataRow dr in dt.Rows)
                { sittingId = (int)dr.ItemArray.First(); }
                if (sittingId != 0)
                {
                    Console.WriteLine(sittingId);
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            Assert.IsTrue(result);
        }
    }
}
