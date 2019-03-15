using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ParkSqlDAOTests : NPGeekDAOTests
    {
        [TestMethod]
        public void GetParks_Should_ReturnListCount1()
        {
            //Arrange
            ParkSqlDAO parkDao = new ParkSqlDAO(ConnectionString);
            //Act
            IList<Park> parks = parkDao.GetParks();
            //Assert
            Assert.AreEqual(1, parks.Count);
        }
    }
}
