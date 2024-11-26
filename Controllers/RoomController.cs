using HotelManagementAPI.Models.RoomModels;
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
        [HttpPost]
        public ActionResult Create([FromRoute] int hotelId, [FromBody] CreateRoomDto roomDto)
        {
            var roomId = _roomService.CreateRoom(hotelId, roomDto);
            return Created($"New room with id {roomId} was created in hotel with id: {hotelId}", null);
        }
        [HttpPut("{roomId}")]
        public ActionResult Update([FromRoute] int hotelId, [FromRoute] int roomId, [FromBody] UpdateRoomDto roomDto)
        {
            _roomService.UpdateRoom(hotelId, roomId, roomDto);
            return Ok();
        }
        [HttpDelete("{roomId}")]
        public ActionResult DeleteById([FromRoute] int hotelId, [FromRoute] int roomId)
        {
            _roomService.DeleteRoomById(hotelId, roomId);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int hotelId)
        {
            _roomService.DeleteAllRooms(hotelId);
            return NoContent();
        }
        [HttpGet("available-rooms")]
        public ActionResult GetAvailableRooms([FromRoute] int hotelId, [FromQuery] DateTime from, [FromQuery] DateTime? to)
        {
            var availableRooms = _roomService.GetAvailableRooms(hotelId, from, to);
            return Ok(availableRooms);
        }
    }
}
