using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayar
{
    public class UsersData
    {

        public static int NumberOfUsers()
        {
            int NumberOfUsers = 0;

            string Quere = @" Select Count(*) from Users
          Select SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    NumberOfUsers = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return NumberOfUsers;
        }

        public static DataTable GetAllUser()
        {
            DataTable Users = new DataTable();

            string Quere = @"SELECT        Users.UserID, Users.PersonID, People.FirstName+' '+ People.SecondName+
case 
when People.ThirdName Is NULL then ''
else ' '+ People.ThirdName
end
+' '+ People.LastName As FullName, Users.UserName, Users.IsActive
FROM            People INNER JOIN
                         Users ON People.PersonID = Users.PersonID

";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Users.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Users;
        }

        public static bool FindUserByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password,
            ref bool IsActive)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM Users WHERE UserID=@UserID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

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

        public static bool FindUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password,
            ref bool IsActive)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM Users WHERE PersonID=@PersonID";

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
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
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

        public static bool FindUserByUserNameAndPassword(string UserName, string Password, ref int PersonID, ref int UserID ,
            ref bool IsActive)
        {
            bool IsFound = false;

            string Quere = "SELECT * FROM Users WHERE UserName=@UserName And Password=@Password";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
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


        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = 0;

            string Quere = @"INSERT INTO [dbo].[Users]
           ([PersonID]
           ,[UserName]
           ,[Password]
           ,[IsActive])
     VALUES
           (@PersonID
           ,@UserName
           ,@Password
           ,@IsActive)
          Select SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    UserID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[Users]
   SET [PersonID] = @PersonID
      ,[UserName] = @UserName
      ,[Password] = @Password
      ,[IsActive] = @IsActive
 WHERE UserID=@UserID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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


        public static bool DeleteUser(int UserID)
        {
            bool IsFound = false;

            string Quere = @"DELETE FROM [dbo].[Users] 
            WHERE UserID=@UserID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            string Quere = "SELECT Found=1 FROM Users WHERE PersonID=@PersonID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
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

        public static bool IsUserExistThisUserName(string UserName)
        {
            bool IsFound = false;

            string Quere = "SELECT Found=1 FROM Users WHERE UserName=@UserName";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
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


        public static bool IsUserExistByID(int UserID)
        {
            bool IsFound = false;

            string Quere = "SELECT Found=1 FROM Users WHERE UserID=@UserID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
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


        public static bool ChangePassword(int UserID,  string NewPassword)
        {
            bool IsFound = false;

            string Quere = @"UPDATE [dbo].[Users]
   SET [Password] = @Password
 WHERE UserID=@UserID";

            SqlConnection connection = new SqlConnection(clsStringConnection.StringConnection);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            command.Parameters.AddWithValue("@Password", NewPassword);
           

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

    }
}
