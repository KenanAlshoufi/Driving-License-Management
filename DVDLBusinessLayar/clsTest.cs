using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class clsTest 
    {

        public enum enMode { AddNew=0, Update=1};

        enMode Mode=enMode.AddNew;
        public int TestID {  get; set; }

        public int TestAppointmentID {  get; set; }
        public TestAppointment TestAppointmentInfo;
        public bool TestResult {  get; set; }
        public string Notes {  get; set; }
         public int CreatedByUserID {  get; set; }


        public clsTest() {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = 0;
            Mode = enMode.AddNew;
        }

        public clsTest(int TestID, int TestAppointmentID, bool TestResult,
          string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID=TestAppointmentID ;
            TestAppointmentInfo=TestAppointment.FindTestAppointmentByID(TestAppointmentID) ;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this. CreatedByUserID = CreatedByUserID;

            Mode=enMode.Update;
        }


        private  bool _AddNewTest()
        {
            this.TestID = TestData.AddNewTest(TestAppointmentID, TestResult,
          Notes, CreatedByUserID);

            return (this.TestID != -1);
        }


        private bool _UpdateTest()
        {
            return TestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult,
         this.Notes, this.CreatedByUserID);

        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                    case enMode.Update:
                    return _UpdateTest();
                    break;
            }

            return false;   
        }


        public static clsTest FindTestByID(int TestID)
        {
            int TestAppointmentID = -1;  
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;


            if (TestData.FindTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID,TestAppointmentID,TestResult,Notes,CreatedByUserID);
            }
            return null;

        }

        
        public static clsTest GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, int LicenseClassID, TestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            if (TestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                 (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
             ref TestAppointmentID, ref TestResult,
             ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,TestAppointmentID, TestResult,Notes, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllTest()
        {
            return clsTest.GetAllTest();
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return TestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }
    }
}
