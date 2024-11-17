﻿using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.RoomModels;

namespace HotelManagementAPI.Models.HotelModels
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Rating { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string? PostalCode { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
