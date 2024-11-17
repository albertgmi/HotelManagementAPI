using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Services.HotelServiceFolder;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("/api/hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _hotelService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var result = _hotelService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateHotelDto hotelDto)
        {
            var hotelId = _hotelService.Create(hotelDto);
            return Created($"Hotel with id: {hotelId} created", null);
        }
        [HttpPut("{hotelId}")]
        public ActionResult Update([FromRoute]int hotelId, [FromBody] UpdateHotelDto hotelDto)
        {
            _hotelService.Update(hotelId, hotelDto);
            return NoContent();
        }
        [HttpDelete("{hotelId}")]
        public ActionResult Delete([FromRoute] int hotelId)
        {
            _hotelService.Delete(hotelId);
            return NoContent();
        }
        [HttpPost("{hotelId}/assign-manager")]
        public ActionResult AssignManager([FromRoute] int hotelId, [FromQuery] int userId)
        {
            _hotelService.AssignManager(hotelId, userId);
            return Ok();
        }
        [HttpGet("{hotelId}/manager")]
        public ActionResult GetManager([FromRoute] int hotelId)
        {
            var manager = _hotelService.GetManager(hotelId);
            return Ok(manager);
        }
        [HttpPost("{hotelId}/add-rating")]
        public ActionResult AddRating([FromRoute]int hotelId, [FromQuery]decimal rating)
        {
            _hotelService.AddRating(hotelId, rating);
            return Ok();
        }

    }
}
