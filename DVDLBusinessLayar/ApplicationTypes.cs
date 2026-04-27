using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class ApplicationTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

       

        public ApplicationTypes()

        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
            Mode = enMode.AddNew;

        }
        ApplicationTypes(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationFees = applicationFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return ApplicationTypesData.GetAllApplicationTypes();
        }

        public static ApplicationTypes FindApplicationTypesByID(int ApplicationTypeID)
        {
            string applicationTypeTitle = "";
            decimal applicationFees = 0;

            if (ApplicationTypesData.FindApplicationTypesByID(ApplicationTypeID, ref applicationTypeTitle, ref applicationFees))
            {
                return new ApplicationTypes(ApplicationTypeID, applicationTypeTitle, applicationFees);

            }

            return null;

        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = ApplicationTypesData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);


            return (this.ApplicationTypeID != -1);
        }



        private bool _UpdateApplicationTypes()
        {
            return ApplicationTypesData.UpdateApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationTypes();

            }

            return false;
        }
    }
}
