namespace HotelManagementAPI.Models.ReportModels
{
    public class FinancialReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public int ReservationCount { get; set; }
        public decimal AverageRevenuePerReservation { get; set; }
    }
}
