using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Returns a list of all the parks.
        /// </summary>
        /// <returns></returns>
        IList<Park> GetParks();

        /// <summary>
        /// Returns an individual park.
        /// </summary>
        /// <returns></returns>
        Park GetPark(string parkCode);

        IList<DailyWeather> GetForecast(string parkCode);

        IList<Survey> GetSurveys(string parkCode);

        void AddSurvey(Survey survey);
    }
}
