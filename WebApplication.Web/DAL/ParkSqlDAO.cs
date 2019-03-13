using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO: IParkDAO
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
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM park ORDER BY parkName;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }
            }
            catch(SqlException ex)
            {
                //LOG??!?!@?#?'
                throw;
            }
            return parks;
        }

        /// <summary>
        /// Converts a reader object to a park.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
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
            park.FiveDayForecast = GetForecast(park.ParkCode);

            return park;
        }


        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM park WHERE parkCode = @parkCode;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park = ConvertReaderToPark(reader);
                    }
                }
            }
            catch (SqlException x)
            {
                //LOG?!
                throw;
            }
            return park;
        }

        private IList<DailyWeather> GetForecast(string parkCode)
        {
            IList<DailyWeather> forecast = new List<DailyWeather>();
            try
            {
               using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM weather WHERE parkCode = @parkCode;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DailyWeather weather = ConvertReaderToDailyWeather(reader);
                        forecast.Add(weather);
                    }

                }

            }
            catch (SqlException x)
            {
                //LOG%#$$%^$%^&%^&*&^@#$%R?
                throw;
            }
            return forecast;
        }

        private DailyWeather ConvertReaderToDailyWeather(SqlDataReader reader)
        {
            DailyWeather weather = new DailyWeather();
            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(reader["low"]);
            weather.High = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);

            return weather;
        }
    }
}
