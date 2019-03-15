using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM park ORDER BY parkName;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = this.ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                // LOG??!?!@?#?'
                throw;
            }

            return parks;
        }

        /// <summary>
        /// Converts a reader object to a park.
        /// </summary>
        /// <param name="reader">reader object</param>
        /// <returns>Park object</returns>
        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkCode = Convert.ToString(reader["parkCode"]);
            park.ParkName = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Acreage = Convert.ToInt32(reader["acreage"]);
            park.ElevationInFt = Convert.ToInt32(reader["elevationInFeet"]);
            park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
            park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            park.Quote = Convert.ToString(reader["inspirationalQuote"]);
            park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.Description = Convert.ToString(reader["parkDescription"]);
            park.EntryFee = Convert.ToInt32(reader["entryFee"]);
            park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return park;
        }

        /// <summary>
        /// Gets a park for the given park code.
        /// </summary>
        /// <param name="parkCode">Park Code</param>
        /// <returns>Park Object</returns>
        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM park WHERE parkCode = @parkCode;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park = this.ConvertReaderToPark(reader);
                    }
                }
            }
            catch (SqlException x)
            {
                // LOG?!
                throw;
            }

            return park;
        }

        /// <summary>
        /// Returns a list of DailyWeather objects for a given park code.
        /// </summary>
        /// <param name="parkCode">Park code</param>
        /// <returns>IList of DailyWeather objects</returns>
        public IList<DailyWeather> GetForecast(string parkCode)
        {
            IList<DailyWeather> forecast = new List<DailyWeather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM weather WHERE parkCode = @parkCode;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DailyWeather weather = this.ConvertReaderToDailyWeather(reader);
                        forecast.Add(weather);
                    }
                }
            }
            catch (SqlException x)
            {
                // LOG%#$$%^$%^&%^&*&^@#$%R?
                throw;
            }

            return forecast;
        }

        /// <summary>
        /// Returns a list of surveys for a the given park code.
        /// </summary>
        /// <param name="parkCode">Park Code</param>
        /// <returns>IList of Surveys</returns>
        public IList<Survey> GetSurveys(string parkCode)
        {
            IList<Survey> surveys = new List<Survey>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM survey_result WHERE parkCode = @parkCode;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Survey survey = this.ConvertReaderToSurvey(reader);
                        surveys.Add(survey);
                    }
                }
            }
            catch (SqlException x)
            {
                // Log?
                throw;
            }

            return surveys;
        }

        /// <summary>
        /// Converts a reader object to a Survey object.
        /// </summary>
        /// <param name="reader">reader object</param>
        /// <returns>Survey Object</returns>
        private Survey ConvertReaderToSurvey(SqlDataReader reader)
        {
            Survey survey = new Survey();
            survey.SurveyId = Convert.ToInt32(reader["surveyId"]);
            survey.ParkCode = Convert.ToString(reader["parkCode"]);
            survey.Email = Convert.ToString(reader["emailAddress"]);
            survey.State = Convert.ToString(reader["state"]);
            survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);

            return survey;
        }

        /// <summary>
        /// Converts a reader object to a DailyWeather object.
        /// </summary>
        /// <param name="reader">Reader Object</param>
        /// <returns>DailyWeather Object</returns>
        private DailyWeather ConvertReaderToDailyWeather(SqlDataReader reader)
        {
            DailyWeather weather = new DailyWeather();
            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(reader["low"]);
            weather.High = Convert.ToInt32(reader["high"]);
            weather.LowDisplay = Convert.ToInt32(reader["low"]);
            weather.HighDisplay = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);

            return weather;
        }

        /// <summary>
        /// Saves a survey to the database.
        /// </summary>
        /// <param name="survey">Survey object</param>
        public void AddSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO survey_result VALUES(@parkCode, @emailAddress, @state, @activityLevel);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException x)
            {
                // LOG
                throw;
            }
        }
    }
}