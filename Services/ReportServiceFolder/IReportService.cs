using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.ReportModels;

namespace HotelManagementAPI.Services.ReportServiceFolder
{
    public interface IReportService
    {
        OccupancyReport GenerateOccupancyRaport(Hotel hotel, DateTime startDate, DateTime endDate);
    }
}
