using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class Drivers
    {

        public enum enMode { AddNew = 0, Update = 1 }

        public enMode mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        public People PersonInfo;
        public Drivers()
        {
            this.DriverID = 0;
            this.PersonID = 0;
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = 0;
        }

        Drivers(int driverID, int personID, DateTime createdDate, int createdByUserID)
        {
            DriverID = driverID;
            PersonID = personID;
            PersonInfo = People.FindByPersonID(personID);
            CreatedDate = createdDate;
            CreatedByUserID = createdByUserID;
        }


        public static DataTable GetAllDrivers()
        {
            return DriverDate.GetAllDrivers();
        }

        public static Drivers FindDriverByPersonID(int PersonID)
        {
            int DriverID = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = 0;
            if (DriverDate.FindDriverByPersonID(ref DriverID, PersonID, ref CreatedDate, ref CreatedByUserID))
            {
                return new Drivers(DriverID, PersonID, CreatedDate, CreatedByUserID);
            }
            return null;
        }

        public static Drivers FindDriverByID(int DriverID)
        {
            int PersonID = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = 0;

            if (DriverDate.FindDriverByID(DriverID, ref PersonID, ref CreatedDate, ref CreatedByUserID))
            {
                return new Drivers(DriverID, PersonID, CreatedDate, CreatedByUserID);
            }
            return null;

        }


        private bool _AddNewDriver()
        {
            this.DriverID = DriverDate.AddNewDriver(PersonID, CreatedByUserID);

            return this.DriverID != -1;
        }


        private bool _UpdateDriver()
        {
            return DriverDate.UpdateDriver(DriverID, PersonID, CreatedByUserID);
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        return true;
                    }
                    else { return false; }


                case enMode.Update:
                    return _UpdateDriver();
            }
            return false;
        }


        public static DataTable GetAllLocalDrivingLicenseByDriverID(int DriverID)
        {
            return Licenses.GetDriverLicense(DriverID);    
        }

        //public static DataTable GetInternationalLicenses(int DriverID)
        //{
        //    return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        //}
    }
}
