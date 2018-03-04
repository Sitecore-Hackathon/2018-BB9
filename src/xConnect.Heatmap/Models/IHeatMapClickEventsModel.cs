using System;

namespace xConnect.HeatMap.Models
{
    /// <summary>
    /// The heat map click events model interface
    /// </summary>
    public interface IHeatMapClickEventsModel
    {
        /// <summary>
        /// Gets or sets the component identifier.
        /// </summary>
        /// <value>
        /// The component identifier.
        /// </value>
        Guid ComponentId { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        int Count { get; set; }

        /// <summary>
        /// Gets or sets the normalized count.
        /// </summary>
        /// <value>
        /// The normalized count.
        /// </value>
        int NormalizedCount { get; set; }
    }
}