using System;
using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;

namespace EPi.Cms.SiteSettings.Impl
{
    [ServiceConfiguration(ServiceType = typeof(ISiteSettingsRepository), Lifecycle = ServiceInstanceScope.Singleton)]
    public class StartPageSiteSettingsRepository : ISiteSettingsRepository
    {
        protected IContentRepository _contentRepository;
        protected SiteDefinitionRepository _siteDefinitionRepository;

        public StartPageSiteSettingsRepository(IContentRepository contentRepository, SiteDefinitionRepository siteDefinitionRepository)
        {
            _contentRepository = contentRepository;
            _siteDefinitionRepository = siteDefinitionRepository;
        }

        public T Get<T>(SiteDefinition site = null, LoaderOptions loaderOptions = null) where T : ISiteSettings
        {
            site = site ?? SiteDefinition.Current;
            loaderOptions = loaderOptions ?? new LoaderOptions() { LanguageLoaderOption.Fallback() };

            var startPage = _contentRepository.Get<IContent>(site.StartPage, loaderOptions);
            return (T)startPage;
        }

        public IEnumerable<T> GetAll<T>(LoaderOptions loaderOptions = null) where T : ISiteSettings
        {
            foreach(var siteDefinition in _siteDefinitionRepository.List())
            {
                yield return Get<T>(siteDefinition, loaderOptions);
            }
        }
    }
}
