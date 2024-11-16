﻿namespace HotelManagementAPI.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // Relations
        public List<User> Users { get; set; } = new List<User>();
    }
}
