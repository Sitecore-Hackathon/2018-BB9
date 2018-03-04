using System;

namespace xConnect.HeatMap.Models
{
    /// <summary>
    /// The heat map click events model
    /// </summary>
    /// <seealso cref="xConnect.HeatMap.Models.IHeatMapClickEventsModel" />
    public class HeatMapClickEventsModel : IHeatMapClickEventsModel
    {
        /// <summary>
        /// Gets or sets the component identifier.
        /// </summary>
        /// <value>
        /// The component identifier.
        /// </value>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the normalized count.
        /// </summary>
        /// <value>
        /// The normalized count.
        /// </value>
        public int NormalizedCount { get; set; }
    }
}