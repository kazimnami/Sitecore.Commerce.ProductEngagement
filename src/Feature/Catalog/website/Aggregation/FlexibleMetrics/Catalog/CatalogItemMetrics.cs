using Sitecore.Analytics.Aggregation.Data.Model;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Metrics;
using System;

namespace SampleEngagement.Feature.Catalog.Aggregation.FlexibleMetrics.Catalog
{
    public abstract class CatalogItemMetrics : DictionaryValue, IMergeableMetric<CatalogItemMetrics>
    {
        public int Visits { get; set; }
        public int Value { get; set; }
        public int ItemValue { get; set; }
        public decimal MonetaryValue { get; set; }
        public decimal ItemMonetaryValue { get; set; }
        public int Conversions { get; set; }
        public int ItemConversions { get; set; }
        public int Pageviews { get; set; }
        public int ItemPageviews { get; set; }
        public int Bounces { get; set; }
        public int TimeOnPage { get; set; }
        public int TimeOnSite { get; set; }
        public int OutcomeOccurrences { get; set; }
        public int ItemOutcomeOccurrences { get; set; }

        public virtual T MergeWith<T>(T other) where T : CatalogItemMetrics, new()
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            T obj = new T();
            obj.Visits = this.Visits + other.Visits;
            obj.Value = this.Value + other.Value;
            obj.ItemValue = this.ItemValue + other.ItemValue;
            obj.MonetaryValue = this.MonetaryValue + other.MonetaryValue;
            obj.ItemMonetaryValue = this.ItemMonetaryValue + other.ItemMonetaryValue;
            obj.Conversions = this.Conversions + other.Conversions;
            obj.ItemConversions = this.ItemConversions + other.ItemConversions;
            obj.Pageviews = this.Pageviews + other.Pageviews;
            obj.ItemPageviews = this.ItemPageviews + other.ItemPageviews;
            obj.Bounces = this.Bounces + other.Bounces;
            obj.TimeOnPage = this.TimeOnPage + other.TimeOnPage;
            obj.TimeOnSite = this.TimeOnSite + other.TimeOnSite;
            obj.OutcomeOccurrences = this.OutcomeOccurrences + other.OutcomeOccurrences;
            obj.ItemOutcomeOccurrences = this.ItemOutcomeOccurrences + other.ItemOutcomeOccurrences;
            return obj;
        }

    }
}