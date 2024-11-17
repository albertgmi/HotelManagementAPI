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
    }
}
