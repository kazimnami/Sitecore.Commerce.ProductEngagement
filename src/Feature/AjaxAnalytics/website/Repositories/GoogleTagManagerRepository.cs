using SampleEngagement.Feature.AjaxAnalytics.Models;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleEngagement.Feature.AjaxAnalytics.Repositories
{
    public class GoogleTagManagerRepository : ModelRepository, IGoogleTagManagerRepository
    {
        public override IRenderingModelBase GetModel() 
        {
            var model = new GoogleTagManagerModel();
            this.FillBaseProperties(model);
            model.Key = this.Rendering.Parameters["Key"];
            return model;
        }
    }
}