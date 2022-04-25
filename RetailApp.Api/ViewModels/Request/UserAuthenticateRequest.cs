﻿namespace RetailApp.Api.ViewModels.Request
{
    public class UserAuthenticateRequest
    {
        public string Email { get; set; }
        public String Password { get; set; }

        /// <summary>
        /// For Test
        /// </summary>
        public int CustomerType { get; set; }

    }
}
