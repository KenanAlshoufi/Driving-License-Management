using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public  class User
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public People PersonInfo;
        
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public User()
        {
            this.UserID = 0;
            this.PersonID = 0;
            this.UserName = "";
            this.Password = "";

            this.IsActive = false;
            Mode = enMode.AddNew;
        }
        private User(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this .PersonInfo=People.FindByPersonID (PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return UsersData.GetAllUser();
        }

        private bool _AddNewUser()
        {
            this.UserID = UsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            if (this.UserID != 0)
            {
                return true;
            }
            else
                return false;
        }

        private bool _UpdateUser()
        {
            return UsersData.UpdateUser(UserID, PersonID, UserName, Password, IsActive);
           
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateUser())
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }



        public static bool DeleteUser(int UserID)
        {
            return UsersData.DeleteUser(UserID);
        }


        public static bool IsExistByPersonID(int PersonID)
        {
            return UsersData.IsUserExistByPersonID(PersonID);
        }

        public static bool IsExistThisUserName(string UserName)
        {
            return UsersData.IsUserExistThisUserName(UserName);
        }

        public static bool IsUserExistByID(int UserID)
        {
            return UsersData.IsUserExistByID(UserID);
        }


        public static User FindUserByUserID(int UserID)
        {
            
            int PersonID = 0;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (UsersData.FindUserByUserID(UserID,ref PersonID,ref UserName,ref Password,ref IsActive))
            {
                return new User(UserID,  PersonID,  UserName,  Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static User FindUserByPersonID(int PersonID)
        {
            int UserID = 0;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (UsersData.FindUserByPersonID(PersonID, ref UserID,  ref UserName, ref Password, ref IsActive))
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static User FindUserByUserNameAndPassword(string UserName ,string Password)
        {
            int UserID = 0;
            int PersonID = 0;
            bool IsActive = false;

            if (UsersData.FindUserByUserNameAndPassword(UserName, Password, ref PersonID, ref UserID,ref IsActive))
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            return UsersData.ChangePassword(UserID, NewPassword);
        }

        public static int NumberOfUsers()
        {
            return UsersData.NumberOfUsers();
        }

    }
}
