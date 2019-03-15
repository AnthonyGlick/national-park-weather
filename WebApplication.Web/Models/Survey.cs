using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents a user survey.
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Gets or sets the Id for the survey.
        /// </summary>
        public int SurveyId { get; set; }

        /// <summary>
        /// Gets or sets the Park Code for the park the survey covers.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the state the user resides in.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets user's activity level.
        /// </summary>
        public string ActivityLevel { get; set; }
    }
}
