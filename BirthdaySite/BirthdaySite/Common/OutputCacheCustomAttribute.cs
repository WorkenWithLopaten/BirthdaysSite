using System.Web.Mvc;

namespace BirthdaySite.Common
{
    public class OutputCacheCustomAttribute : OutputCacheAttribute
    {
        public OutputCacheCustomAttribute()
        {
            CacheProfile = "Custom";
        }
    }
}