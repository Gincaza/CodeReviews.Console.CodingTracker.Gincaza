using BusinessLogicLayer.ComunicationClasses;
using BusinessLogicLayer.DataClasses;
using System.Globalization;

namespace BusinessLogicLayer
{
    public class BLLClass
    {
        //private static DataAccessLayer dataAccess;


        public BLLClass(/*DataAccessLayer dataAccess*/) 
        {
            //this.dataAccess = dataAccess
        }

        public static OperationResult InitializeDatabase()
        {
            //this.dataAccess.InitDatabase();
            return new OperationResult(true);
        }
        
        public static OperationResult AddTimeRecord(string starTime, string endTime)
        {
            return new OperationResult(true);
        }

        public static List<TimeRecord> SeeTimeRecord() 
        {
            return new List<TimeRecord>();
        }

        public static OperationResult DeleteTimeRecord(TimeRecord timeRecord)
        {
            return new OperationResult(true);
        }

        public void DeleteTimeRecord(int id)
        {

        }
    }
}
