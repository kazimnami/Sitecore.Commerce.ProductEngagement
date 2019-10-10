using Sitecore.Analytics.Aggregation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.FactCalculation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Goal;
using Sitecore.Marketing.Taxonomy.Model;
using Sitecore.XConnect;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Analytics.Core;
using Sitecore.Analytics.Model;
using Sitecore.Commerce.CustomModels.PageEvents;
using Sitecore.Commerce.CustomModels.Outcomes;
using Sitecore.Commerce.ExperienceAnalytics.Currency;
using Sitecore.Commerce.ExperienceAnalytics;

namespace SampleEngagement.Feature.Catalog.Aggregation.FlexibleMetrics.Catalog
{
    public class CatalogItemFactCalculator<T, U> : IFactCalculator<T, U>
        where T : CatalogItemMetrics, new()
        where U : BaseCustomPageEvent, new()
    {
        public T CalculateFactsForGroup(
          VisitGroupMeasurement<U> groupMeasurement,
          IInteractionAggregationContext context)
        {
            if (groupMeasurement == null)
                throw new ArgumentNullException(nameof(groupMeasurement));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var itemId = groupMeasurement.Occurrences.First().ItemId;
            var productId = groupMeasurement.Id.Id.Split('_').Last();

            var visitPageEventList = context.Interaction.Events.OfType<PageViewEvent>().ToList();
            var visitGoalList = context.Interaction.Events.OfType<Goal>().ToList();
            var visitOrderOutcomeList = context.Interaction.Events.OfType<SubmittedOrderOutcome>().ToList();
            var itemPageEventList = visitPageEventList.Where(pageEvent => pageEvent.ItemId.Equals(itemId)).ToList();
            var itemGoalList = visitGoalList.Where(goal =>
                (goal.DataKey?.Equals("productId")).GetValueOrDefault() &&
                (goal.Data?.Equals(productId)).GetValueOrDefault());

            var cartLineList = visitOrderOutcomeList
                .SelectMany(outcome => outcome.Order.CartLines
                    .Select(cartLine => new {
                        outcomeId = outcome.Id,
                        cartLine.Product.ProductId,
                        cartLine.Total,
                        outcome.Timestamp }))
                .Where(cartLineSummary => cartLineSummary.ProductId.Equals(productId))
                .ToList();

            T metric = new T
            {
                Visits = 1,
                Value = context.Interaction.EngagementValue,
                ItemValue = itemGoalList.Sum(goal => goal.EngagementValue),
                MonetaryValue = visitOrderOutcomeList.Sum(outcome => outcome.MonetaryValue),
                ItemMonetaryValue = cartLineList.Sum(item => ConvertCurrency(item.Timestamp, item.Total.Amount, item.Total.CurrencyCode)),
                Conversions = visitGoalList.Count,
                ItemConversions = itemGoalList.Count(),
                Pageviews = visitPageEventList.Count,
                ItemPageviews = groupMeasurement.Occurrences.Count(),
                Bounces = visitPageEventList.Count == 1 ? 1 : 0,
                TimeOnPage = ConvertDurationToSeconds(itemPageEventList.Sum(pageEvent => pageEvent.Duration.TotalMilliseconds)),
                TimeOnSite = ConvertDurationToSeconds(visitPageEventList.Sum(pageEvent => pageEvent.Duration.TotalMilliseconds)),
                OutcomeOccurrences = visitOrderOutcomeList.Count,
                ItemOutcomeOccurrences = cartLineList.Select(line => line.outcomeId).Distinct().Count()
            };

            return metric;
        }

        private static int ConvertDurationToSeconds(double duration)
        {
            if (duration <= 0.0)
                return 0;
            return (int)Math.Round(duration / 1000.0);
        }

        protected decimal ConvertCurrency(DateTime transactionDate, decimal amount, string amountCurrency)
        {
            return CurrencyConverterFactory.Current.Convert(transactionDate, amount, amountCurrency, CommerceAnalyticsContext.Current.ReportingCurrency);
        }
    }
}