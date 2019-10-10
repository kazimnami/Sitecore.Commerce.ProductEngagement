using Sitecore.Analytics.Aggregation;
using Sitecore.Commerce.CustomModels.PageEvents;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
using Sitecore.XConnect;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleEngagement.Feature.Catalog.Aggregation.FlexibleMetrics.Catalog
{
    public abstract class CatalogItemResolver<T> : IGroupResolver<T> where T : BaseCustomPageEvent
    {
        public virtual IEnumerable<VisitGroupMeasurement<T>> MeasureGroupOccurrences(
          IInteractionAggregationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return context.Interaction.Events
                .OfType<T>()
                .GroupBy(pageEvent => pageEvent.ItemId)
                .Select(pageEventOccurences => new VisitGroupMeasurement<T>(
                    new VisitGroup(ConstructDimensionKey(context, pageEventOccurences.Key)), 
                    pageEventOccurences));
        }

        private string ConstructDimensionKey(IInteractionAggregationContext context, Guid itemId)
        {
            var itemPageEventList = context.Interaction.Events.OfType<PageViewEvent>().Where(pageEvent => pageEvent.ItemId.Equals(itemId)).ToList();
            var catalogItemId = itemPageEventList.First().Url.Split('/').Last().Split('?').First();

            return $"{itemId.ToString()}_{catalogItemId}";
        }
    }
}
