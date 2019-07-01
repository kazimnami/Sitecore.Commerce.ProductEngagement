# Sitecore.AjaxAnalytics
A Sitecore module to allow analytics to be posted into xDB asynchronously

# Installation
Note these instructions are based on Habitat Home, to install into a different site they may vary.
* Install sitecore package for the latest release version of this module.
* Add the AjaxAnalytics Extension theme to your site theme.
* Include the _GTM-Head_ meta rendering into the _head_ placeholder of the _Global Metadata_ Partial Design
* Include the _GTM-Body_ meta rendering into the _body-top_ placeholder of the _Global Metadata_ Partial Design
* Use GTM to assign events to the elements on the site.