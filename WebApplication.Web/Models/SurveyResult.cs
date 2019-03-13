using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyResult
    {
        /// <summary>
        /// The number of surveys submitted for a particular park.
        /// </summary>
        public int SurveyCount { get; set; }
        /// <summary>
        /// The park we are getting results for.
        /// </summary>
        public Park Park { get; set; }

    }
}
