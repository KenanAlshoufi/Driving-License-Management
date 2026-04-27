using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public class ApplicationTypesData
    {

        public static DataTable GetAllApplicationTypes()
        {

            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string Query = "SELECT * FROM ApplicationTypes order by ApplicationTypeTitle";

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

        public static bool UpdateApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[ApplicationTypes]
   SET [ApplicationTypeTitle] = @ApplicationTypeTitle
      ,[ApplicationFees] = @ApplicationFees
 WHERE ApplicationTypeID=@ApplicationTypeID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


            try
            {
                connection.Open();

                int Result = command.ExecuteNonQuery();

                if (Result > 0)
                {
                    IsFound = true;
                }

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

        public static bool FindApplicationTypesByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID=@ApplicationTypeID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];

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


        public static int AddNewApplicationType(string Title, decimal Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;

        }

    }
}
