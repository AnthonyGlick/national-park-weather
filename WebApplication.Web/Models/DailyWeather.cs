using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DailyWeather
    {
        /// <summary>
        /// Gets or sets the identity string for the park the forecast belongs to.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or sets the day (starting at today = day 1) for the forcast.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets the low temperature for the day.
        /// </summary>
        public int Low { get; set; }

        /// <summary>
        /// Gets or sets the high temperature for the day.
        /// </summary>
        public int High { get; set; }

        /// <summary>
        ///Gets or sets the low temperature display for the day.
        /// </summary>
        public int LowDisplay { get; set; }

        /// <summary>
        /// Gets or sets the high temperature display for the day.
        /// </summary>
        public int HighDisplay { get; set; }

        /// <summary>
        /// Gets or sets the Forecast of the weather for the park on a given day.
        /// </summary>
        public string Forecast { get; set; }
    }
}
