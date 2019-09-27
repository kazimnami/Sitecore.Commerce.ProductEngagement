using SampleEngagement.Feature.AjaxAnalytics.Models;
using SampleEngagement.Feature.AjaxAnalytics.Repositories;
using Sitecore.Analytics;
using Sitecore.XA.Foundation.Mvc.Controllers;
using Sitecore.XConnect;
using Sitecore.XConnect.Client.Configuration;
using System;
using System.Web.Mvc;

namespace SampleEngagement.Feature.AjaxAnalytics.Controllers
{
    public class GoogleTagManagerController : StandardController
    {
        protected IGoogleTagManagerRepository Repository { get; }

        public GoogleTagManagerController(IGoogleTagManagerRepository repository)
        {
            this.Repository = repository;
        }

        protected override object GetModel()
        {
            return this.Repository.GetModel();
        }
    }
}