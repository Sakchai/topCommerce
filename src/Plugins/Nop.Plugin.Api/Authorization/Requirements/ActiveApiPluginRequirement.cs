﻿using Microsoft.AspNetCore.Authorization;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.Api.Authorization.Requirements
{
    public class ActiveApiPluginRequirement : IAuthorizationRequirement
    {
        public bool IsActive()
        {
            var settings = EngineContext.Current.Resolve<ApiSettings>();

            if (settings.EnableApi)
            {
                return true;
            }

            return false;
        }
    }
}