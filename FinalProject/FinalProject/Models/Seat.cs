namespace FinalProject.Models
{
    public class Seat
    {
        public int ID { get;set; }
        public string SeatCode { get;set; }
        public string OccName { get;set; }
        public string OccAuth { get; set; }
        public bool Reserved { get; set; }
    }
}