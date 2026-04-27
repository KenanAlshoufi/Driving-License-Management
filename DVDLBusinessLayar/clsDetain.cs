using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class clsDetain
    {
        public int DetainID {  get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public User CreatedByUserInfo { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }


        clsDetain(int DetainID,int LicenseID,  DateTime DetainDate,  decimal FineFees,  int CreatedByUserID,
            bool IsReleased,  DateTime ReleaseDate,  int ReleasedByUserID,  int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo=User.FindUserByUserID(this.CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;   

        }

        public clsDetain()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees =0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

        }


        private  bool _AddNewDetain()
        {
            this.DetainID = DetainData.AddNewDetain(LicenseID, FineFees, CreatedByUserID);

            return (this.DetainID!=-1);
        }

        public bool ReleaseDetain(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return DetainData.ReleaseDetain(this.DetainID, ReleasedByUserID, ReleaseApplicationID);
        }


        public bool Save()
        {
            if (_AddNewDetain())
            {
                return true;
            }

            return false;
        }

        public static clsDetain FindDetainByID(int DetainID)
        {
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            int LicenseID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;


            if (DetainData.FindDetainByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
           ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetain(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
            IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }

            return null;
        }


        public static clsDetain FindDetainByLicenseID(int LicenseID)
        {
            DateTime DetainDate = DateTime.Now;
                decimal FineFees = 0;
            int CreatedByUserID = -1;
            int DetainID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate=DateTime.Now;
                int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;


            if (DetainData.FindDetainByLicenseID(LicenseID,ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID,
           ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetain(DetainID,LicenseID, DetainDate,  FineFees,  CreatedByUserID,
            IsReleased,  ReleaseDate,  ReleasedByUserID,  ReleaseApplicationID);
            }

            return null;
        }


        public static DataTable GetAllDetain()
        {
            return DetainData.GetAllDetain();
        }


        public static bool IsLicenseDetain(int LicenseID)
        {
            return DetainData.IsLicenseDetain(LicenseID);
        }

        public bool IsLicenseDetain()
        {
            return DetainData.IsLicenseDetain(LicenseID);
        }


    }
}
