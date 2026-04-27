using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public class CountriesData
    {
        public static bool FindCountryByID(int CountryID, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string Query = "SELECT * FROM Countries where CountryID = @CountryID";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CountryName = (string)reader["CountryName"];
                   
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }

            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static bool FindCountryByName(ref int CountryID, string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string Query = "SELECT * FROM Countries where CountryName = @CountryName";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CountryID = (int)reader["CountryID"];
                   
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }

            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool IsCountryExist(string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string Query = "SELECT Found=1 FROM Countries where CountryName = @CountryName";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                IsFound = (Result != null);


            }
            catch (Exception ex)
            {
                IsFound = false;
            }

            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string Query = "SELECT * FROM Countries ";

            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {

                    dataTable.Load(reader);
                }

                reader.Close();


            }
            catch (Exception ex)
            {

            }

            finally { connection.Close(); }

            return dataTable;
        }
    }
}
