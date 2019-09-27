using SampleEngagement.Feature.AjaxAnalytics.Models;
using Sitecore.Analytics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client.Configuration;
using System;
using System.Web.Mvc;

namespace SampleEngagement.Feature.AjaxAnalytics.Controllers
{
    public class AjaxAnalyticsController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult RegisterProductGoal(string goalId, string productId)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var goal = Tracker.MarketingDefinitions.Goals[new Guid(goalId)];
                    var pageData = new Sitecore.Analytics.Data.PageEventData(goal.Alias, goal.Id)
                    {
                        Data = productId,
                        Text = "Triggered goal from front-end interaction",
                        DataKey = "productId"
                    };

                    Tracker.Current.CurrentPage.Register(pageData);

                    string result = "{success:true}";
                    return Json(result);
                }
                catch (XdbExecutionException ex)
                {
                    return new HttpStatusCodeResult(500, "Unable to log interaction.");
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult RegisterGoal(string goalId, string productId)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var goal = Tracker.MarketingDefinitions.Goals[new Guid(goalId)];
                    var pageData = new Sitecore.Analytics.Data.PageEventData(goal.Alias, goal.Id)
                    {
                        Data = productId,
                        Text = "Triggered goal from front-end interaction",
                        DataKey = "productId"
                    };

                    Tracker.Current.CurrentPage.Register(pageData);

                    string result = "{success:true}";
                    return Json(result);
                }
                catch (XdbExecutionException ex)
                {
                    return new HttpStatusCodeResult(500, "Unable to log interaction.");
                }
            }
        }
    }
}