using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

namespace HotelManager.Web.WebShare.Attribute
{
    public class CustomizeCacheAttribute : OutputCacheAttribute

    {

        public CustomizeCacheAttribute(string cacheProfileName)

        {

            OutputCacheSettingsSection cacheSettings =

                (OutputCacheSettingsSection)WebConfigurationManager

                .GetSection("system.web/caching/outputCacheSettings");

            OutputCacheProfile cacheProfile = cacheSettings.OutputCacheProfiles[cacheProfileName];

            Duration = cacheProfile.Duration;

            VaryByParam = cacheProfile.VaryByParam;

            VaryByCustom = cacheProfile.VaryByCustom;

        }

    }
}