using DVDLDataAccessLayar;
using System.Data;

namespace DVDLBusinessLayar
{
    public class TestTypes
    {

       public enum enTestType { VisionTest = 1, writtenTest = 2, StreetTest = 3 };
        public TestTypes.enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        


        TestTypes(TestTypes.enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
           
        }

        public static DataTable GetAllTestTypes()
        {
            return TestTypesData.GetAllTestTypes();
        }

        public static TestTypes FindTestTypesByID(TestTypes.enTestType TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            if (TestTypesData.FindTestTypeByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription,ref TestTypeFees))
            {
                return new TestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

            }

            return null;

        }




        public  bool UpdateTestTypes()
        {
            return TestTypesData.UpdateTestTypes((int)TestTypeID,  TestTypeTitle,  TestTypeDescription, TestTypeFees);

        }

      

    }
}
