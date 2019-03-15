using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyResult
    {
        /// <summary>
        /// Gets or sets the number of surveys submitted for a particular park.
        /// </summary>
        public int SurveyCount { get; set; }

        /// <summary>
        /// Gets or sets the park we are getting results for.
        /// </summary>
        public Park Park { get; set; }
    }
}
