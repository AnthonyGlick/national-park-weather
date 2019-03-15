using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ParkDetail
    {
        /// <summary>
        /// Gets or sets the park we want to view details on.
        /// </summary>
        public Park Park { get; set; }

        /// <summary>
        /// Gets or sets the five day forecast for the park.
        /// </summary>
        public IList<DailyWeather> FiveDayForecast { get; set; }

        /// <summary>
        /// Gets or sets the surveys for the park.
        /// </summary>
        public IList<Survey> Surveys { get; set; }
    }
}
