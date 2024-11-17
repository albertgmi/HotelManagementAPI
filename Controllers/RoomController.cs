using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("/api/{hotelId}/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet("available-rooms")]
        public ActionResult GetAvailableRooms([FromRoute] int hotelId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return Ok();
        }
    }
}
