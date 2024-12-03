using HotelManagementAPI.Entities;
using QuestPDF.Fluent;

namespace HotelManagementAPI.Services.ReportServiceFolder
{
    public interface IReportService
    {
        Document GenerateFullReport(Hotel hotel, DateTime startDate, DateTime endDate);
    }
}
