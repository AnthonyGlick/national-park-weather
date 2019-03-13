using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface ISurveyDAO
    {

        /// <summary>
        /// Adds a survey into the storage system.
        /// </summary>
        void AddSurvey(Survey survey);

    }
}
