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
        [TestMethod]
        public void GetForecasts_Should_ReturnListCount5()
        {

            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            IList<DailyWeather> forecast = dao.GetForecast("CVNP");

            Assert.AreEqual(5, forecast.Count);
        }

        [TestMethod]
        public void GetSurveys_Should_ReturnCount0()
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            IList<Survey> surveys = dao.GetSurveys("CVNP");

            Assert.AreEqual(1, surveys.Count);
        }
        [TestMethod]
        public void AddSurvey_Should_IncreaseSurveysCountBy1()
        {

            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            Survey survey = new Survey() { Email = "Bob@bob.com", ParkCode = "CVNP", State = "Ohio", ActivityLevel = "active" };
            dao.AddSurvey(survey);

            Assert.AreEqual(2, dao.GetSurveys("CVNP").Count);
        }
    }
}
