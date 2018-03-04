using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xConnect.HeatMap.Models;
using xConnect.HeatMap.Models.Models;

namespace xConnect.HeatMap.Services
{
    /// <summary>
    /// The heat map collector service
    /// </summary>
    /// <seealso cref="xConnect.HeatMap.Services.IHeatMapCollectorService" />
    public class HeatMapCollectorService : IHeatMapCollectorService
    {
        /// <summary>
        /// The channel identifier - /sitecore/system/Marketing Control Panel/Taxonomies/Channel/Online/HeatMap/HeatMap
        /// </summary>
        private static readonly Guid ChannelId = new Guid("{2EA8FB7F-B249-466C-8CD8-A01899412960}");

        /// <summary>
        /// The normalization upper value (RGB max)
        /// </summary>
        private static int NormalizationUpperValue = 255;

        /// <summary>
        /// Clicks the specified page identifier.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <param name="componentId">The component identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>Async task</returns>
        public async Task ClickAsync(Guid pageId, Guid componentId, string language)
        {
            try
            {
                using (var client = SitecoreXConnectClientConfiguration.GetClient())
                {
                    var contact = new Contact();
                    client.AddContact(contact);

                    var interaction = new Interaction(contact, InteractionInitiator.Brand, ChannelId, string.Empty);

                    var click = new ClickEvent(ClickEvent.EventDefintionId, DateTime.UtcNow)
                    {
                        PageId = pageId,
                        ComponentId = componentId,
                        Language = language
                    };

                    interaction.Events.Add(click);


                    client.AddInteraction(interaction);

                    await client.SubmitAsync();
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e, this);
            }
        }

        /// <summary>
        /// Gets the clicks.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>Async click events</returns>
        public async Task<IEnumerable<IHeatMapClickEventsModel>> GetClicksAsync(Guid pageId, string language)
        {
            try
            {
                using (var client = SitecoreXConnectClientConfiguration.GetClient())
                {
                    var q = client
                        .Interactions
                        .Where(e => e.Events.OfType<ClickEvent>().Any(ce => ce.PageId == pageId && ce.Language == language));

                    var results = await q.ToList();

                    var grouppedResult = results
                        .SelectMany(r => r.Events.OfType<ClickEvent>())
                        .GroupBy(e => e.ComponentId)
                        .Select(g => new HeatMapClickEventsModel { ComponentId = g.Key, Count = g.Count() })
                        .ToList();

                    return this.Normalize(grouppedResult);
                };
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e, this);
                return Enumerable.Empty<IHeatMapClickEventsModel>();
            }
        }

        /// <summary>
        /// Normalizes the specified groupped result.
        /// </summary>
        /// <param name="grouppedResult">The groupped result.</param>
        /// <returns>Returns the list items with NormalizedCount</returns>
        private IEnumerable<IHeatMapClickEventsModel> Normalize(IEnumerable<IHeatMapClickEventsModel> grouppedResult)
        {
            var maxCount = grouppedResult.Max(c => c.Count);
            var minCount = grouppedResult.Min(c => c.Count);
            decimal delta = maxCount - minCount;

            foreach (var click in grouppedResult)
            {
                click.NormalizedCount = (int)Math.Round(((click.Count - minCount) / delta) * NormalizationUpperValue);
            }

            return grouppedResult;
        }
    }
}