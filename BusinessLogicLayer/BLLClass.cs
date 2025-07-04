using BusinessLogicLayer.ComunicationClasses;
using BusinessLogicLayer.DataClasses;
using System.Globalization;

namespace BusinessLogicLayer
{
    public class BLLClass
    {
        private DataAccessLayer.Class1 dataAccess;

        public BLLClass()
        {
            this.dataAccess = new DataAccessLayer.Class1();
        }

        public OperationResult InitializeDatabase()
        {
            try
            {
                //bool createDatabase = this.dataAccess.InitDatabase();
                bool createDatabase = true;
                if (createDatabase)
                {
                    return new OperationResult(true, "Success creating the Database.");
                }
                else
                {
                    return new OperationResult(false, "Failed creating the Database.");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }

        }

        public OperationResult AddTimeRecord(string starTime, string endTime)
        {
            try
            {
                if (string.IsNullOrEmpty(starTime) || string.IsNullOrEmpty(endTime))
                {
                    return new OperationResult(false, "No start or end was given.");
                }

                var timeDifference = TimeDifferenceCalc(starTime, endTime);
                var formattedTimeDifference = TimeDifferenceFormatted(timeDifference) ?? "00:00";

                var timeRecord = new TimeRecord(0, starTime, endTime, formattedTimeDifference);

                //bool success = dataAccess.AddTimeRecordToDatabase(timeRecord);
                bool success = true; //TODO - when finish with the DatabaseLayer we comeback here

                if (success)
                {
                    return new OperationResult(true, "Register add with success.");
                }
                else
                {
                    return new OperationResult(false, "Register failt to add.");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public List<TimeRecord> SeeTimeRecord()
        {
            return new List<TimeRecord>();
        }

        public OperationResult DeleteTimeRecord(TimeRecord timeRecord)
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