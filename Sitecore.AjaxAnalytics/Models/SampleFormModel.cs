using Sitecore.XA.Foundation.Mvc.Models;

namespace Sitecore.AjaxAnalytics.Models
{
    public class SampleFormModel : RenderingModelBase
    {
        public string GoalId { get; set; }
        public string SendingText = "Sending";
    }
}