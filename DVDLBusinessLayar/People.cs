using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class People
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        private string _ImagePath;
        public string ImagePath
        { get { return _ImagePath; } set { _ImagePath = value; } }

        public Countries InfoCountries;

        public string FullName {  get; set; }

        enum enMode { AddNew=0, Update=1 };
        enMode Mode= enMode.AddNew;

        public People()
        {
            PersonID = 0;
            NationalNo ="" ;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = 0;
            ImagePath = "";
            Mode = enMode.AddNew;
        }
        private People(int personID, string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, short gendor, string address, string phone, 
            string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            FullName = firstName + " " + secondName + " " +thirdName + " " + lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            InfoCountries=Countries.FindCountryByID(NationalityCountryID);
            Mode = enMode.Update;
        }

        public static DataTable GetAllPesron()
        {
            return PeopleData.GetAllPerson();
        }

        public bool _AddNewPerson()
        {
            this. PersonID = PeopleData.AddNewPerson( NationalNo, FirstName, SecondName,
             ThirdName, LastName, DateOfBirth, Gendor, Address
            , Phone, Email, NationalityCountryID, ImagePath);

            return (this.PersonID != -1);
        }

        public bool _UpdatePerosn()
        {
            return (PeopleData.UpdatePerson(PersonID, NationalNo, FirstName, SecondName,
             ThirdName, LastName, DateOfBirth, Gendor, Address
            , Phone, Email, NationalityCountryID, ImagePath));
           
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                       Mode= enMode.Update;
                        return true;
                    }
                    break;
                   
                case enMode.Update:
                    return (_UpdatePerosn());
                    break;
            }
            return false;
        }



        public static bool DeletePerson(int PersonID)
        {
            return PeopleData.DeletePerson(PersonID);
        }


        public static bool IsPersonExist(int PersonID)
        {
            return PeopleData.IsPersonExist(PersonID);
        }

       public static bool IsPersonExist(string NationalNo)
        {
            return PeopleData.IsPersonExist(NationalNo);
        }


        public static People FindByPersonID(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
         string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
             int NationalityCountryID = 0;
            string ImagePath = "";

            if (PeopleData.FindByPersonID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
           ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address
            , ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new People(PersonID,  NationalNo,  FirstName,  SecondName,
            ThirdName,  LastName,  DateOfBirth,  Gendor,  Address
            ,  Phone,  Email,  NationalityCountryID,  ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static People FindByNationalNo(string NationalNo)
        {
            int PersonID = 0;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = 0;
            string ImagePath = "";

            if (PeopleData.FindByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
           ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address
            , ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new People(PersonID, NationalNo, FirstName, SecondName,
            ThirdName, LastName, DateOfBirth, Gendor, Address
            , Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

    }
}
