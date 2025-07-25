using BusinessLogicLayer.ComunicationClasses;
using System.Globalization;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DataClasses;

namespace BusinessLogicLayer
{
    public class BLLClass
    {
        private readonly ICodingSessionRepository _codingSessionRepository;

        public BLLClass(ICodingSessionRepository codingSessionRepository)
        {
            this._codingSessionRepository = codingSessionRepository;
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

                if (timeDifference == null)
                {
                    return new OperationResult(false, "Invalid date format or start time is after end time");
                }

                var formattedTimeDifference = TimeDifferenceFormatted(timeDifference) ?? "00:00";

                var session = new CodingSession
                {
                    Id = 0,
                    StartDate = starTime,
                    EndDate = endTime,
                    Duration = formattedTimeDifference,
                };

                bool success = this._codingSessionRepository.AddCodingSession(session);

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

        public List<CodingSession> SeeTimeRecord()
        {
            try
            {
                return this._codingSessionRepository.GetAllCodingSessions();
            }
            catch (Exception)
            {
                return new List<CodingSession>();
            }
        }

        public OperationResult DeleteTimeRecord(CodingSession timeRecord)
        {
            try
            {
                bool deleteOperation = this._codingSessionRepository.DeleteCodingSession(timeRecord.Id);

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

        public OperationResult UpdateTimeRecord(CodingSession timeRecord)
        {
            try
            {
                if (timeRecord.Id > 0)
                {
                    var timeDifference = TimeDifferenceCalc(timeRecord.StartDate, timeRecord.EndDate);

                    if (timeDifference == null)
                    {
                        return new OperationResult(false, "Invalid date format or start time is after end time.");
                    }

                    var formattedTimeDifference = TimeDifferenceFormatted(timeDifference) ?? "00:00";

                    timeRecord.Duration = formattedTimeDifference;

                    bool updateOperation = _codingSessionRepository.UpdateCodingSession(timeRecord);

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
                if (start < end)
                {
                    return end - start;
                }
                return null;
            }

            return null; //return null if can't convert
        }

        //returns in a formated in hours string
        private string? TimeDifferenceFormatted(TimeSpan? TimeDifference)
        {
            return TimeDifference?.ToString(@"hh\:mm\:ss");
        }
        
    }
}