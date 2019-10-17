# Sitecore.Commerce.EngagementWithGoogleTagManager
A Sitecore module to allow analytics to be posted into xDB asynchronously
This is built against Sitecore Experience Commerce 9.2

# Build from Source
Currently the Sitecore.Commerce.ExperienceAnalytics.dll doesn't exist in the Sitecore nuget feed. This is a required reference for this project.
To build the solution, copy your Sitecore.Commerce.ExperienceAnalytics.dll from your _bin_ directory to the _lib_ folder in the root of this solution.
You can then build and deploy the two web projects to your wwwroot folder.

## Item Serialisation
Item serialistion is handled via TDS and is using YAML format.

# Configuration
You will then need to configure this for your site, by including the Javascript elements onto your page. The instructions below will demonstrate how to achieve this with Habiatat Home, but the item locations for your site will be different.
* Add the AjaxAnalytics Extension theme located at _/sitecore/media library/Extension Themes/AjaxAnalytics Extension_ to your site theme (in HabitatHome.Commerce this is located at _/sitecore/media library/Themes/Habitat SXA Sites/Habitat Home Store_).
* Update your sites available renderings to enable the GTM renderings. (In HabitatHome update the _/sitecore/content/Habitat SXA Sites/Global/Presentation/Available Renderings/Analytics_ item's _renderings_ fields to referance both _/sitecore/layout/Renderings/Feature/Analytics/Google Tag Manager Head_ & _/sitecore/layout/Renderings/Feature/Analytics/Google Tag Manager Body_ to enable this for all sites)
* Open your MetaData Partial Design (In HabitatHome we're going to update the global meta data to include the functionality on all sites, this is located at _/sitecore/content/Habitat SXA Sites/Global/Presentation/Partial Designs/Global Metadata_) in the Experience Editor.
* Add the Google Tag Manager Head rendering (located under _Analytics_ in the toolbox) to the _head_ placeholder. Enter your Google Tag Manager Container Id into the Key field on the Rendering parameters.
* Add the Google Tag Manager Body rendering (located under _Analytics_ in the toolbox) to the _body_ placeholder. Enter your Google Tag Manager Container Id into the Key field on the Rendering parameters.
* Save your changes to the Meta Partial Rendering, then publish your site.

You're now ready to start triggering events via GTM!