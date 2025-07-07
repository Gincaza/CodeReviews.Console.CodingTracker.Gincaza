using BusinessLogicLayer.ComunicationClasses;
using System.Globalization;
using DataClasses;
using DataClasses.BLLClasses;

namespace BusinessLogicLayer
{
    public class BLLClass
    {
        private DataAccessLayer.DatabaseManager dataAccess;

        public BLLClass()
        {
            this.dataAccess = new DataAccessLayer.DatabaseManager();
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

                var timeRecord = new CodingSessionDto(0, starTime, endTime, formattedTimeDifference);

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

        public List<CodingSessionDto> SeeTimeRecord()
        {
            return new List<CodingSessionDto>();
        }

        public OperationResult DeleteTimeRecord(CodingSessionDto timeRecord)
        {
            try
            {
                //bool deleteOperation = dataAccess.DeleteTimeRecord(timeRecord.id);
                bool deleteOperation = true;

                if (deleteOperation)
                {
                    return new OperationResult(true, "Success in delete Time Record.");
                }
                else
                {
                    return new OperationResult(false, "Failed in delete Time Record.");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public OperationResult UpdateTimeRecord(CodingSessionDto timeRecord)
        {
            try
            {
                if (timeRecord.Id > 0)
                {
                    // bool updateOperation = dataAccess.UpdateTimeRecord(timeRecord.id);
                    bool updateOperation = true;

                    if (updateOperation)
                    {
                        return new OperationResult(true, $"Success in update Time Record {timeRecord.Id}");
                    }
                    else
                    {
                        return new OperationResult(false, $"Failed in update Time Record {timeRecord.Id}");
                    }
                }
                else
                {
                    return new OperationResult(false, "Invalid Time Record ID.");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
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
        
        private CodingSessionDto ToCodingSessonDto(DataClasses.DataLayerClasses.CodingSessionEntity entity)
        {
            return new CodingSessionDto(
                entity.Id,
                entity.StartDate,
                entity.EndDate,
                entity.AllTime
                );
        }
    }
}