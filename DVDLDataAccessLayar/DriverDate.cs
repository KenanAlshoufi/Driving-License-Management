using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public class DriverDate
    {
        public static int AddNewDriver( int PersonID,
 int CreatedByUserID)

        {
            int DriverID = -1;

            string Quere = @"INSERT INTO [dbo].[Drivers]
           ([PersonID]
           ,[CreatedByUserID]
           ,[CreatedDate])
     VALUES
           (@PersonID,@CreatedByUserID,@CreatedDate)
          Select SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    DriverID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }


        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[Drivers]
   SET [PersonID] = @PersonID
      ,[CreatedByUserID] = @CreatedByUserID
      ,[CreatedDate] = @CreatedDate
 WHERE DriverID=@DriverID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
           
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



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

      
        public static bool FindDriverByID(int DriverID,ref int PersonID,
        ref DateTime CreatedDate,ref int CreatedByUserID)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM Drivers WHERE DriverID=@DriverID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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



        public static bool FindDriverByPersonID(ref int DriverID, int PersonID,
        ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM Drivers WHERE PersonID=@PersonID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        public static DataTable GetAllDrivers()
        {
            DataTable AllDrivers = new DataTable();

            string Quere = @"SELECT * FROM Drivers_View order by FullName";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    AllDrivers.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                AllDrivers = null;
            }
            finally
            {
                connection.Close();
            }

            return AllDrivers;
        }


    }
}
