﻿namespace LeadMedixCRM.DTOs
{
    public class AuthUserDto
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
