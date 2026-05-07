using DVDLBusinessLayar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Driving_License_Management
{
    public class clsGlobal
    {
        public static User CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDUserName";
            string ValueName = "UserName";
            string ValueDate = Username;
            string ValueName2 = "Password";
            string ValueDate2 = Password;

            try
            {
               
                    Registry.SetValue(KeyPath, ValueName, ValueDate, RegistryValueKind.String);
                    Registry.SetValue(KeyPath, ValueName2, ValueDate2, RegistryValueKind.String);
              

                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDUserName";
            string ValueName = "UserName";
            string ValueName2 = "Password";
           

            try
            {
                //gets the current project's directory
             
                
                    Username = (string)Registry.GetValue(KeyPath, ValueName, RegistryValueKind.String);
                    Password = (string)Registry.GetValue(KeyPath, ValueName2, RegistryValueKind.String);


                return true;
            }
            catch (Exception ex)

            {
                return false;
            }

        }
    }
}
