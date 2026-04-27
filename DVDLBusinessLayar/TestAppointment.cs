using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class TestAppointment
    {

       
        public enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;
        public int TestAppointmentID { get; set; }
        public TestTypes.enTestType  TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public Applications RetakeTestApplicationInfo { get; set; }


        public int TestID
        {
            get { return GetTestID(); }

        }

        public  TestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = TestTypes.enTestType.VisionTest;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;

            _Mode = enMode.AddNew;
        }

        TestAppointment(int TestAppointmentID, TestTypes.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate
                        , decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            RetakeTestApplicationInfo = Applications.FindBaseApplication(RetakeTestApplicationID);

            _Mode = enMode.Update;
        }


        public static TestAppointment FindTestAppointmentByID(int TestAppointmentID)
        {
            int LocalDrivingLicenseApplicationID = 0, TestTypeID = 0, CreatedByUserID = 0, RetakeTestApplicationID = 0;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            if (TestAppointmentData.FindTestAppointmentByID(TestAppointmentID, ref LocalDrivingLicenseApplicationID, ref TestTypeID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new TestAppointment(TestAppointmentID, (TestTypes.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }


        }

        public static DataTable GetAllTestAppointmentByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID)
        {
            return TestAppointmentData.GetAllTestAppointmentByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID,(int) TestTypeID);
        }


        public static TestAppointment GetLasttestAppointment(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID)
        {
            int TestAppointmentID = 0, CreatedByUserID = 0, RetakeTestApplicationID = 0;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            if (TestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID ,(int) TestTypeID, ref TestAppointmentID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new TestAppointment(TestAppointmentID, (TestTypes.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }


        }

        public static DataTable GetAllTestAppointment()
        {
            return TestAppointmentData.GetAllTestAppointment();
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = TestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
           this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return TestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
           this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case enMode.Update:
                    return _UpdateTestAppointment();
                    break;
            }
            return false;
        }


        public  int GetTestID()
        {
            return TestAppointmentData.GetTestID(TestAppointmentID);
        }
    }
}

