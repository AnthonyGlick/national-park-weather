using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Transactions;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class NPGeekDAOTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=NPGeek;Trusted_Connection=True;";
        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        protected string ParkCode { get; private set; }

        protected int SurveyId { get; private set; }

        protected int FiveDayForecastValue { get; private set; }


        [TestInitialize]
        public void Setup()
        {
            //Begin the transaction
            transaction = new TransactionScope();
            //Get the SQL Script to run
            string sql = File.ReadAllText("test-script.sql");

            //Execute the script
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
            }
        }
        /// <summary>
        /// Rolls back the transaction.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

    }
}
