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

        //calc the difference by time
        private TimeSpan? TimeDifferenceCalc(string startDate, string endDate)
        {
            if (DateTime.TryParseExact(startDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var start) &&
                DateTime.TryParseExact(endDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var end))
            {
                return end - start;
            }

            return null; // return null if can't convert
        }
        
        //returns in a formated in hours string
        private string? TimeDifferenceFormatted(TimeSpan? TimeDifference)
        {
            var diff = TimeDifference;
            return diff.HasValue ? diff.Value.ToString(@"hh\:mm\:ss") : null;
        }
    }
}
