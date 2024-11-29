using HotelManagementAPI.Models.ReservationModels;
using HotelManagementAPI.Services.ReservationServiceFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HotelManagementAPI.Controllers
{
    [Route("/api/hotel/{hotelId}/room/{roomId}/reservation")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAll([FromRoute] int hotelId, [FromRoute] int roomId) 
        {
            var reservations = _reservationService.GetAll(hotelId, roomId);
            return Ok(reservations);
        }
        [HttpGet("{reservationId}")]
        [AllowAnonymous]
        public ActionResult GetById([FromRoute] int hotelId, [FromRoute] int roomId, [FromRoute] int reservationId)
        {
            var reservation = _reservationService.GetById(hotelId, roomId, reservationId);
            return Ok(reservation);
        }
        [HttpPost]
        public ActionResult Create([FromRoute] int hotelId, [FromRoute] int roomId, [FromBody] CreateReservationDto createReservationDto)
        {
            var reservationId = _reservationService.Create(hotelId, roomId, createReservationDto);
            return Ok($"Reservation with id {reservationId} was made for room with id {roomId} in hotel {hotelId}");
        }
        [HttpDelete("{reservationId}")]
        public ActionResult Delete([FromRoute] int hotelId, [FromRoute] int roomId, [FromRoute] int reservationId)
        {
            _reservationService.Delete(hotelId, roomId, reservationId);
            return NoContent();
        }
        [HttpPut("{reservationId}")]
        public ActionResult Update([FromRoute] int hotelId, [FromRoute] int roomId, [FromRoute] int reservationId, [FromBody] UpdateReservationDto dto)
        {
            _reservationService.Update(hotelId, roomId, reservationId, dto);
            return NoContent();
        }
    }
}
