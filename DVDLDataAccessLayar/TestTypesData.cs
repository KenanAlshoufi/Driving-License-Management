using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public class TestTypesData
    {
        public static DataTable GetAllTestTypes()
        {

            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            string Query = "SELECT * FROM TestTypes";

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

        public static bool UpdateTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription , decimal TestTypeFees)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[TestTypes]
   SET [TestTypeTitle] =@TestTypeTitle
      ,[TestTypeDescription] =@TestTypeDescription
      ,[TestTypeFees] = @TestTypeFees
 WHERE TestTypeID=@TestTypeID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


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

        public static bool FindTestTypeByID(int TestTypeID,ref string TestTypeTitle,ref string TestTypeDescription,ref decimal TestTypeFees)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM TestTypes WHERE TestTypeID=@TestTypeID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (decimal)reader["TestTypeFees"];

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


    }
}
