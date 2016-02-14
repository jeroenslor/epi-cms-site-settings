# epi-cms-site-settings
Add support for site settings. This library hides the way sitesettings are retreived by using a ISiteSettingsRepository. The default implementation is the StartPageSiteSettingRepository which retreives the settings from the startpage contentype. This type must derive from the ISiteSettings interface.
