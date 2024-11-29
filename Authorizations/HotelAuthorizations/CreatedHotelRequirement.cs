﻿using Microsoft.AspNetCore.Authorization;

namespace HotelManagementAPI.Authorizations.HotelAuthorizations
{
    public class CreatedHotelRequirement : IAuthorizationRequirement
    {
        public ResourceOperation Operation { get; set; }
        public CreatedHotelRequirement(ResourceOperation operation)
        {
            Operation = operation;
        }
    }
}
