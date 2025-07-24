namespace DataClasses.BLLClasses;

public class CodingSessionDto
{
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Duration { get; set; }

    public CodingSessionDto(int id, string startDate, string endDate, string duration)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        Duration = duration;
    }
}