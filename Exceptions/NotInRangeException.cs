﻿namespace HotelManagementAPI.Exceptions
{
    public class NotInRangeException : Exception
    {
        public NotInRangeException(string options) : base(options)
        {
            
        }
    }
}
