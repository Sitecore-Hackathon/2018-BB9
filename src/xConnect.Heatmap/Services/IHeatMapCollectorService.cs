using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xConnect.HeatMap.Models;

namespace xConnect.HeatMap.Services
{
    /// <summary>
    /// The heat map collector service interface
    /// </summary>
    public interface IHeatMapCollectorService
    {
        /// <summary>
        /// Clicks the specified page identifier.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <param name="componentId">The component identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>Async task</returns>
        Task ClickAsync(Guid pageId, Guid componentId, string language);

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>Async click events</returns>
        Task<IEnumerable<IHeatMapClickEventsModel>> GetClicksAsync(Guid pageId, string language);
    }
}