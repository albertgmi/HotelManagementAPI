using HotelManagementAPI.Services.HotelServiceFolder;
using HotelManagementAPI.Services.RoomServiceFolder;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("/api/hotel/{hotelId}/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult GetAll([FromRoute] int hotelId)
        {
            var rooms = _roomService.GetAll(hotelId);
            return Ok(rooms);
        }
        [HttpGet("{roomId}")]
        public ActionResult GetById([FromRoute] int hotelId, [FromRoute] int roomId)
        {
            var room = _roomService.GetById(hotelId, roomId);
            return Ok(room);
        }
        [HttpGet("available-rooms")]
        public ActionResult GetAvailableRooms([FromRoute] int hotelId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return Ok();
        }
    }
}
