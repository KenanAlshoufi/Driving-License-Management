using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static DVDLBusinessLayar.Licenses;

namespace DVDLBusinessLayar
{
    public class Licenses
    {

        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementforDamaged = 3, ReplacementforLost = 4 }



        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        
        
        public int DriverID { get; set; }

        public Drivers DriverInfo;

        public int LicenseclassID { get; set; }
        public LicenseClass licenseClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public enIssueReason IssueReason { get; set; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }


        public clsDetain DetainedInfo { set; get; }
        public bool IsDetained
        {
            get { return clsDetain.IsLicenseDetain(this.LicenseID); }
        }



        public Licenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.LicenseclassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            
        }

        Licenses(int LicenseID, int ApplicationID, int DriverID, int Licenseclass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes
           , decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseclassID = Licenseclass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DetainedInfo = clsDetain.FindDetainByLicenseID(this.LicenseID);
            DriverInfo =Drivers.FindDriverByID(DriverID);
            licenseClassInfo = LicenseClass.FindLicenseByID(this.LicenseclassID);
        }


        public static DataTable GetAllLicense()
        {
            return LicenseDate.GetAllLicense();
        }

        public static DataTable GetDriverLicense(int DriverID)
        {
            return LicenseDate.GetDriverLicense(DriverID);
        }


        public static Licenses FindLicenseByID(int LicenseID)
        {

            int ApplicationID = 0;
            int DriverID = 0;
            int LicenseClass = 0;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = 0;


            if (LicenseDate.FindLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes
            , ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new Licenses(LicenseID, ApplicationID, DriverID, LicenseClass,
             IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }

            return null;
        }

        public static Licenses FindLicenseByApplicationID(int ApplicationID)
        {
            
            int LicenseID = 0;
            int DriverID = 0;
            int LicenseClass = 0;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = 0;


            if (LicenseDate.FindLicenseByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes
            , ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new Licenses(LicenseID, ApplicationID, DriverID, LicenseClass,
             IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }

            return null;
        }


        private bool _AddNewLicense()
        {
            this.LicenseID = LicenseDate.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseclassID,
             this.IssueDate, this.ExpirationDate, this.Notes
            , this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return LicenseDate.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseclassID,
             this.IssueDate, this.ExpirationDate, this.Notes
            , this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public bool Save()
        {

                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewLicense())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateLicense();
                }
            return false;
        }


      private string  GetIssueReasonText(enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";

                case enIssueReason. ReplacementforDamaged:
                    return "Replacement for Damaged";


                   case enIssueReason.ReplacementforLost:
                    return ".Replacement for Lost";

            }
            return "";
        }

        public static bool ISLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID)!=-1);
        }


        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return LicenseDate.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public  Boolean IsLicenseExpired()
        {
            return  (this.ExpirationDate < DateTime.Now);
        }

        public  bool DeactivateLicense()
        {
            return LicenseDate.DeactivateLicense(this.LicenseID);
        }





        public int Detain(decimal FineFees, int CreatedByUserID)
        {
            clsDetain detainedLicense = new clsDetain();

            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToDecimal(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {
                return -1;
            }

            return detainedLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            Applications Application = new Applications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)Applications.enApplicationTypes.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = Applications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = ApplicationTypes.FindApplicationTypesByID((int)Applications.enApplicationTypes.ReleaseDetainedDrivingLicsense).ApplicationFees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;


            return this.DetainedInfo.ReleaseDetain(ReleasedByUserID, Application.ApplicationID);

        }

        public Licenses RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            Applications Application = new Applications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)Applications.enApplicationTypes.RenewDrivingLicenseService;
            Application.ApplicationStatus = Applications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = ApplicationTypes.FindApplicationTypesByID((int)Applications.enApplicationTypes.RenewDrivingLicenseService).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            Licenses NewLicense = new Licenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseclassID = this.LicenseclassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.licenseClassInfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.licenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = Licenses.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateLicense();

            return NewLicense;
        }

        public Licenses Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            //First Create Applicaiton 
            Applications Application = new Applications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.ReplacementforDamaged) ?
                (int)Applications.enApplicationTypes.ReplacementforaDamagedDrivingLicense :
                (int)Applications.enApplicationTypes.ReplacementforaLostDrivingLicense;

            Application.ApplicationStatus = Applications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = ApplicationTypes.FindApplicationTypesByID(Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            Licenses NewLicense = new Licenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseclassID = this.LicenseclassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateLicense();

            return NewLicense;
        }

    }
}
