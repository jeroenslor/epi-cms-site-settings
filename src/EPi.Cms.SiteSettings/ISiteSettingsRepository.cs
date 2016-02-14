using EPiServer.Core;
using EPiServer.Web;
using System.Collections.Generic;

namespace EPi.Cms.SiteSettings
{
    public interface ISiteSettingsRepository
    {
        T Get<T>(SiteDefinition site = null, LoaderOptions loaderOptions = null) where T : ISiteSettings;
        IEnumerable<T> GetAll<T>(LoaderOptions loaderOptions = null) where T : ISiteSettings;
    }
}