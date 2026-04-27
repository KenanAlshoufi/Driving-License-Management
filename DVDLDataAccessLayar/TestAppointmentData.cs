using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public class TestAppointmentData
    {

        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID,  ref int TestAppointmentID,   
            ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            string Quere = @"Select Top 1 * From TestAppointments 
where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And TestTypeID=@TestTypeID order by TestAppointmentID DESC;";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = (reader["RetakeTestApplicationID"] != System.DBNull.Value) ? (int)reader["RetakeTestApplicationID"] : -1;
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

        public static bool FindTestAppointmentByID(int TestAppointmentID, ref int LocalDrivingLicenseApplicationID, ref int TestTypeID,
            ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM TestAppointments WHERE TestAppointmentID=@TestAppointmentID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);



            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = (reader["RetakeTestApplicationID"] != System.DBNull.Value) ? (int)reader["RetakeTestApplicationID"] : -1;
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

        public static DataTable GetAllTestAppointmentByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable AllTestByApplicationId = new DataTable();

            string Quere = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = @TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    AllTestByApplicationId.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                AllTestByApplicationId = null;
            }
            finally
            {
                connection.Close();
            }

            return AllTestByApplicationId;
        }

        public static DataTable GetAllTestAppointment()
        {
            DataTable AllTestAppointment = new DataTable();

            string Quere = @"Select * From TestAppointments_View
order by TestAppointmentID ASC";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);



            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    AllTestAppointment.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                AllTestAppointment = null;
            }
            finally
            {
                connection.Close();
            }

            return AllTestAppointment;
        }

        public static int AddNewTestAppointment(int TestTypeID,int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
           decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
                
        {
            int TestAppointmentID= -1;

            string Quere = @"INSERT INTO [dbo].[TestAppointments]
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
           ,[CreatedByUserID]
           ,[IsLocked]
           ,[RetakeTestApplicationID])
     VALUES
           (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID
           ,@IsLocked
           ,@RetakeTestApplicationID)
          Select SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
               command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
               

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TestAppointmentID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
        }


        public static bool UpdateTestAppointment(int TestAppointmentID,int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
           decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[TestAppointments]
   SET [TestTypeID] = @TestTypeID
      ,[LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID
      ,[AppointmentDate] = @AppointmentDate
      ,[PaidFees] = @PaidFees
      ,[CreatedByUserID] = @CreatedByUserID
      ,[IsLocked] =@IsLocked
      ,[RetakeTestApplicationID] = @RetakeTestApplicationID
 WHERE TestAppointmentID=@TestAppointmentID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
           
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            if (RetakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);


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



        public static int GetTestID(int TestAppointmentID)

        {
            int TestID = -1;

            string Quere = @"Select TestID from Tests Where TestAppointmentID=@TestAppointmentID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
           

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TestID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return TestID;
        }



    }
}
