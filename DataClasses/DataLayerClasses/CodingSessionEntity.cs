namespace DataClasses.DataLayerClasses
{
    public class CodingSessionEntity
    {
        public int Id { get; set; }
        public required string StartDate { get; set; }
        public required string EndDate { get; set; }
        public required string AllTime { get; set; }
    }
}