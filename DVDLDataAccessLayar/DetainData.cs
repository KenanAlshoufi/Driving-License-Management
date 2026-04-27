using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public  class DetainData
    {

        public static int AddNewDetain(int LicenseID,decimal FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            string Quere = @"INSERT INTO [dbo].[DetainedLicenses]
           ([LicenseID]
           ,[DetainDate]
           ,[FineFees]
           ,[CreatedByUserID]
           ,[IsReleased]
           ,[ReleaseDate]
           ,[ReleasedByUserID]
           ,[ReleaseApplicationID])
     VALUES
           (@LicenseID
           ,@DetainDate
           ,@FineFees
           ,@CreatedByUserID
           ,@IsReleased
           ,@ReleaseDate
           ,@ReleasedByUserID
           ,@ReleaseApplicationID)
          Select SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DateTime.Now);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            command.Parameters.AddWithValue("@IsReleased",false);
            command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    DetainID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return DetainID;
        }


        public static bool ReleaseDetain(int DetainID, int ReleasedByUserID,int ReleaseApplicationID)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[DetainedLicenses]
   SET [IsReleased] = @IsReleased
      ,[ReleaseDate] = @ReleaseDate
      ,[ReleasedByUserID] = @ReleasedByUserID
      ,[ReleaseApplicationID] = @ReleaseApplicationID
 WHERE DetainID=@DetainID
";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            
            command.Parameters.AddWithValue("@IsReleased", true);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);



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


        public static bool FindDetainByLicenseID(int LicenseID,ref int DetainID, ref  DateTime  DetainDate, ref decimal FineFees, ref int CreatedByUserID,
           ref bool IsReleased, ref DateTime ReleaseDate , ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM DetainedLicenses WHERE LicenseID=@LicenseID And IsReleased=0";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    DetainID = (int)reader["DetainID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    ReleaseDate = (reader["ReleaseDate"]!=System.DBNull.Value ? (DateTime)reader["ReleaseDate"] : DateTime.Now);
                    ReleasedByUserID = (reader["ReleasedByUserID"] != System.DBNull.Value ? (int)reader["ReleasedByUserID"] :-1); 
                    ReleaseApplicationID = (reader["ReleaseApplicationID"] != System.DBNull.Value ? (int)reader["ReleaseApplicationID"] : -1); ;
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

        public static bool FindDetainByID(int DetainID, ref int LicenseID , ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
           ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM DetainedLicenses WHERE DetainID=@DetainID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);


            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    LicenseID = (int)reader["LicenseID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    ReleaseDate = (reader["ReleaseDate"] != System.DBNull.Value ? (DateTime)reader["ReleaseDate"] : DateTime.Now);
                    ReleasedByUserID = (reader["ReleasedByUserID"] != System.DBNull.Value ? (int)reader["ReleasedByUserID"] : -1);
                    ReleaseApplicationID = (reader["ReleaseApplicationID"] != System.DBNull.Value ? (int)reader["ReleaseApplicationID"] : -1); ;
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


        public static DataTable GetAllDetain()
        {
            DataTable AllDrivers = new DataTable();

            string Quere = @"Select * From DetainedLicenses_View order by IsReleased,DetainID";

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
        public static bool IsLicenseDetain(int LicenseID)
        {

            bool IsFound = false;

            string Quere = @"Select Found=1 from DetainedLicenses
                         where LicenseID=@LicenseID And IsReleased=0;";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsReleased", false);
          


            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result!=null)
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
      
    }
}
