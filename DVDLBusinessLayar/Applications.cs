using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVDLBusinessLayar.Applications;

namespace DVDLBusinessLayar
{
    public class Applications
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        public enum enApplicationTypes
        {
            NewLocalDrivingLicenseService = 1, RenewDrivingLicenseService = 2,
            ReplacementforaLostDrivingLicense = 3,
            ReplacementforaDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }

       public enum enMode { AddNew = 0, Update = 1 };
       
       public enMode mode = enMode.AddNew;


        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }

        public People PersonInfo;
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }

        public ApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";

                    case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";

                    default:
                        return "UnKnow";

                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public User CreateByUserInfo;


        public Applications()
        {
            ApplicationID = 0;
            ApplicantPersonID = 0;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = 0;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;
            mode = enMode.AddNew;
        }

        private Applications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
             int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = People.FindByPersonID(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = ApplicationTypes.FindApplicationTypesByID(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreateByUserInfo = User.FindUserByUserID(this.CreatedByUserID);
            mode = enMode.Update;
        }


        private bool _AddNewApplication()
        {
            this.ApplicationID = ApplicationData.AddNewApplication(ApplicantPersonID, ApplicationDate,
             ApplicationTypeID, Convert.ToByte(ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID);

            return (ApplicationID != -1);
        }


        private bool _UpdateApplication()
        {
            return ApplicationData.UpdateApplication(ApplicationID, ApplicantPersonID, ApplicationDate,
             ApplicationTypeID, Convert.ToByte(ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID);
        }


        public static Applications FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = 0;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = 0;

            if (ApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate,
            ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new Applications(ApplicationID, ApplicantPersonID, ApplicationDate,
             ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            }
            else
            {
                return null;
            }

        }


        public bool Cancel()
        {
            return ApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Cancelled);
        }

        public bool SetComplete()
        {
            return ApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Completed);
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateApplication())
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }


        public  bool Delete()
        {
            return ApplicationData.DeleteApplication(this.ApplicationID);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return ApplicationData.IsExistApplicationID(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationType)
        {
            return ApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationType);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }


        public static int GetActiveApplicationIDForLicneseClass(int PersonID, enApplicationTypes ApplicationType, int LicenseClassID)
        {
            return ApplicationData.GetActiveApplicationIDForLicneseClass(PersonID, (int)ApplicationType, LicenseClassID);
        }



        public static int GetActiveApplicationID(int PersonID, enApplicationTypes ApplicationType)
        {
            return ApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationType);
        }

        public int GetActiveApplicationID(Applications.enApplicationTypes ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }






    }
}
