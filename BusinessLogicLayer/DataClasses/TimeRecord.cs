namespace BusinessLogicLayer.DataClasses
{
    public class TimeRecord
    {
        public int id;
        public string startDate;
        public string endDate;
        public string allTime;

        public TimeRecord(int id, string startDate, string endDate, string allTime)
        {
            this.id = id;
            this.startDate = startDate;
            this.endDate = endDate;
            this.allTime = allTime;
        }
    }
}
