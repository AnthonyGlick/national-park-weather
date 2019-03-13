using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// A model of a National Park.
    /// </summary>
    public class Park
    {
        /// <summary>
        /// Identitifier for a park.
        /// </summary>
        public string ParkCode { get; set; }
        /// <summary>
        /// Name of the park.
        /// </summary>
        public string ParkName { get; set; }
        /// <summary>
        /// State the park is located in.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The area of the park (in acres)
        /// </summary>
        public int Acreage { get; set; }
        /// <summary>
        /// Elevation in feet of the park.
        /// </summary>
        public int ElevationInFt { get; set; }
        /// <summary>
        /// Total milage of trails.
        /// </summary>
        public double MilesOfTrail { get; set; }
        /// <summary>
        /// Number of campsites in the park.
        /// </summary>
        public int NumberOfCampsites { get; set; }
        /// <summary>
        /// The climate of the park.
        /// </summary>
        public string Climate { get; set; }
        /// <summary>
        /// The year the park was founded.
        /// </summary>
        public int YearFounded { get; set; }
        /// <summary>
        /// The annual visitor count of the park.
        /// </summary>
        public int AnnualVisitorCount { get; set; }
        /// <summary>
        /// An inspirational quote about the park?
        /// </summary>
        public string Quote { get; set; }
        /// <summary>
        /// The person who was quoted.
        /// </summary>
        public string QuoteSource { get; set; }
        /// <summary>
        /// A description of the park.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The cost to enter the park.
        /// </summary>
        public int EntryFee { get; set; }
        /// <summary>
        /// The number of different animal species in the park.
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }
        /// <summary>
        /// The five day forecast for the park.
        /// </summary>
        public IList<DailyWeather> FiveDayForecast { get; set; }

        public IList<Survey> Surveys { get; set; }
    }
}
