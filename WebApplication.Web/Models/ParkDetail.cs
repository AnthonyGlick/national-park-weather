using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ParkDetail
    {
        /// <summary>
        /// Represent a park.
        /// </summary>
        public Park Park { get; set; }

        /// <summary>
        /// The five day forecast for the park.
        /// </summary>
        public IList<DailyWeather> FiveDayForecast { get; set; }

        public IList<Survey> Surveys { get; set; }

    }
}
