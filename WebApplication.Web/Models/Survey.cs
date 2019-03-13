using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents a user survey.
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// The Id for the survey.
        /// </summary>
        public int SurveyId { get; set; }
        /// <summary>
        /// The Park Code for the park the survey covers.
        /// </summary>
        public string ParkCode { get; set; }
        /// <summary>
        /// The user's email address.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// The state the user resides in.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The user's activity level.
        /// </summary>
        public string ActivityLevel { get; set; }
    }
}
