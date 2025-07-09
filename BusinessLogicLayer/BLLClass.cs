using BusinessLogicLayer.ComunicationClasses;
using System.Globalization;
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

                var dto = new CodingSessionDto(0, starTime, endTime, formattedTimeDifference);

                var entity = dataAccess.ToCodingSessionEntity(dto);

                bool success = dataAccess.AddCodingSession(entity);

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
            try
            {
                var entities = dataAccess.GetAllCodingSession();

                List<CodingSessionDto> dtos = new List<CodingSessionDto>();

                foreach (var entity in entities)
                {
                    dtos.Add(ToCodingSessonDto(entity));
                }

                return dtos;
            }
            catch (Exception ex)
            {
                return new List<CodingSessionDto>();
            }
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
                    // Convert CodingSessionDto to CodingSessionEntity before passing to UpdateCodingSession
                    var entity = dataAccess.ToCodingSessionEntity(timeRecord);
                    bool updateOperation = dataAccess.UpdateCodingSession(entity);

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