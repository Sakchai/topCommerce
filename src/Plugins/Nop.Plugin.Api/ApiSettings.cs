﻿using Nop.Core.Configuration;

namespace Nop.Plugin.Api
{
    public class ApiSettings : ISettings
    {
        public bool EnableApi { get; set; } = true;

        public int TokenExpiryInDays { get; set; } = 0;
    }
}
