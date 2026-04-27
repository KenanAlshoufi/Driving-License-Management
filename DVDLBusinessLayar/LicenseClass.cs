using DVDLDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayar
{
    public class LicenseClass
    {
        
        
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }




        LicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
         byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID= LicenseClassID;
            this.ClassName = ClassName;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.ClassDescription = ClassDescription;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

        }

        public static DataTable GetAllLicenseClass()
        {
            return LicenseClassData.GetAllLicenseClass();
        }

        public static LicenseClass FindLicenseByID(int LicenseClassID)
        {
           
             string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (LicenseClassData.FindLicenseByID( LicenseClassID,ref  ClassName, ref ClassDescription,
         ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new LicenseClass(LicenseClassID,  ClassName,  ClassDescription,
          MinimumAllowedAge,  DefaultValidityLength,  ClassFees);

            }

            return null;

        }


        public static LicenseClass FindLicenseByName(string ClassName)
        {
            int LicenseClassID = 0;
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (LicenseClassData.FindLicenseByName(ref LicenseClassID,  ClassName, ref ClassDescription,
         ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new LicenseClass(LicenseClassID, ClassName, ClassDescription,
          MinimumAllowedAge, DefaultValidityLength, ClassFees);

            }

            return null;

        }

        public bool UpdateLicenseClass()
        {
            return LicenseClassData.UpdateLicenseTypes(LicenseClassID, ClassName, ClassDescription,
          MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }

    }
}
