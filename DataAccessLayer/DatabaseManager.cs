using DataClasses.DataLayerClasses;

namespace DataAccessLayer
{
    public class DatabaseManager
    {
        public DatabaseManager()
        {
        }

        public CodingSessionEntity ToCodingSessionEntity(DataClasses.BLLClasses.CodingSessionDto dto)
        {
            return new CodingSessionEntity
            {
                Id = dto.Id,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                AllTime = dto.AllTime
            };
        }
       }
}