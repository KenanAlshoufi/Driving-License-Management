using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class LocalDrivingLicenseApplications : Applications
    {
        enum enMode { AddNew = 0, Update = 1 };

        enMode mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int LicenseClassID { get; set; }
        public LicenseClass LicenseClassInfo;

        public string PerosnFullName
        {
            get { return People.FindByPersonID(ApplicantPersonID).FullName; }
        }


        public LocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationID = 0;
            LicenseClassID = 0;

            mode = enMode.AddNew;
        }


        LocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
             int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = LicenseClass.FindLicenseByID(LicenseClassID);

            mode = enMode.Update;
        }



        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return LocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }


        private bool _AddNewLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplications()
        {
            return LocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplications(
                this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);


        }



        public static LocalDrivingLicenseApplications FindLocalDrivingApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = 0;
            int LicenseClassID = 0;

            bool IsFound = LocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID
                  , ref LicenseClassID);

            if (IsFound)
            {
                Applications applications = Applications.FindBaseApplication(ApplicationID);

                return new LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, applications.ApplicationID, applications.ApplicantPersonID, applications.ApplicationDate,
             applications.ApplicationTypeID, applications.ApplicationStatus, applications.LastStatusDate, applications.PaidFees, applications.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public static LocalDrivingLicenseApplications FindLocalDrivingApplicationByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = 0;
            int LicenseClassID = 0;

            bool IsFound = LocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsInfoByApplicationID(ref LocalDrivingLicenseApplicationID, ApplicationID
                  , ref LicenseClassID);

            if (IsFound)
            {
                Applications applications = Applications.FindBaseApplication(ApplicationID);

                return new LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, applications.ApplicationID, applications.ApplicantPersonID, applications.ApplicationDate,
             applications.ApplicationTypeID, applications.ApplicationStatus, applications.LastStatusDate, applications.PaidFees, applications.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }


        public bool Save()
        {

            base.mode = (Applications.enMode)mode;

            if (!base.Save())
            {
                return false;
            }

            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplications())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplications();


            }

            return false;

        }

        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;


            IsLocalDrivingApplicationDeleted = LocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;

            IsBaseApplicationDeleted = base.Delete();

            return IsBaseApplicationDeleted;
        }

      
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.DoesAttendTestType(LocalDrivingLicenseApplicationID,(int) TestTypeID);
        }

        public  bool DoesAttendTestType(TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID,(int) TestTypeID);
        }

        public  byte TotalTrialsPerTest(TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int) TestTypeID );
        }

        public  bool IsThereAnActiveScheduledTest(TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.DoesPassTestType(LocalDrivingLicenseApplicationID,(int) TestTypeID);
        }

        public  bool DoesPassTestType( TestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        public clsTest GetLastTestPerTestType(TestTypes.enTestType TestTypeID)
        {
            return clsTest.GetLastTestByPersonAndTestTypeAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }


        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            Drivers driver = Drivers.FindDriverByPersonID(this.ApplicantPersonID);

            if (driver == null)
            {
                //we check if the driver already there for this person.
                driver = new Drivers();

                driver.PersonID = this.ApplicantPersonID;
                driver.CreatedByUserID = CreatedByUserID;
                if (driver.Save())
                {
                    DriverID = driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            Licenses License = new Licenses();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseclassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = Licenses.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return Licenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }


    }
}
