# Sitecore.Commerce.EngagementWithGoogleTagManager
A Sitecore module to allow analytics to be posted into xDB asynchronously

This is built against Sitecore Experience Commerce 9.2

# Build from Source
Currently the Sitecore.Commerce.ExperienceAnalytics.dll doesn't exist in the Sitecore nuget feed. This is a required reference for this project.

To build the solution, copy your Sitecore.Commerce.ExperienceAnalytics.dll from your _bin_ directory to the _lib_ folder in the root of this solution.

You can then build and deploy the two web projects to your wwwroot folder.

# Installation
Note these instructions are based on Habitat Home, to install into a different site they may vary.
* Install sitecore package for the latest release version of this module.
* Add the AjaxAnalytics Extension theme to your site theme.
* Include the _GTM-Head_ meta rendering into the _head_ placeholder of the _Global Metadata_ Partial Design
* Include the _GTM-Body_ meta rendering into the _body-top_ placeholder of the _Global Metadata_ Partial Design
* Use GTM to assign events to the elements on the site.