using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DailyWeather
    {
        /// <summary>
        /// Identity string for the park the forecast belongs to.
        /// </summary>
        public string ParkCode { get; set; }
        /// <summary>
        /// Represents the day (starting at today = day 1) for the forcast.
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// Represents the low temperature for the day.
        /// </summary>
        public int Low { get; set; }
        /// <summary>
        /// Represents the high temperature for the day.
        /// </summary>
        public int High { get; set; }
        /// <summary>
        /// Represents the low temperature display for the day.
        /// </summary>
        public int LowDisplay { get; set; }
        /// <summary>
        /// Represents the high temperature display for the day.
        /// </summary>
        public int HighDisplay { get; set; }
        /// <summary>
        /// Forecast of the weather for the park on a given day.
        /// </summary>
        public string Forecast { get; set; }
    }
}
