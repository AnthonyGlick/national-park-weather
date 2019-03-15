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
        /// Gets or sets Identitifier for a park.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or sets Name of the park.
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// Gets or sets State the park is located in.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the area of the park (in acres)
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// Gets or sets elevation in feet of the park.
        /// </summary>
        public int ElevationInFt { get; set; }

        /// <summary>
        /// Gets or sets Total milage of trails.
        /// </summary>
        public double MilesOfTrail { get; set; }

        /// <summary>
        /// Gets or sets the Number of campsites in the park.
        /// </summary>
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// Gets or sets the climate of the park.
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// Gets or sets the year the park was founded.
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// Gets or sets the annual visitor count of the park.
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// Gets or sets the inspirational quote about the park.
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// Gets or sets person who was quoted.
        /// </summary>
        public string QuoteSource { get; set; }

        /// <summary>
        /// Gets or sets the description of the park.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the cost to enter the park.
        /// </summary>
        public int EntryFee { get; set; }

        /// <summary>
        /// Gets or sets the number of different animal species in the park.
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }

    }
}
