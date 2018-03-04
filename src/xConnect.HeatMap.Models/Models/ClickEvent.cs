using Sitecore.XConnect;
using System;

namespace xConnect.HeatMap.Models.Models
{
    /// <summary>
    /// Click event
    /// </summary>
    /// <seealso cref="Sitecore.XConnect.Event" />
    public class ClickEvent : Event
    {
        /// <summary>
        /// The event defintion identifier - /sitecore/system/Settings/Analytics/Page Events/HeatMap/Click
        /// </summary>
        public static readonly Guid EventDefintionId = new Guid("{F4A8A916-8965-4BC1-B6E4-B86E43883732}");

        /// <summary>
        /// Gets or sets the component identifier.
        /// </summary>
        /// <value>
        /// The component identifier.
        /// </value>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Gets or sets the page identifier.
        /// </summary>
        /// <value>
        /// The page identifier.
        /// </value>
        public Guid PageId { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClickEvent"/> class.
        /// </summary>
        /// <param name="definitionId">The definition identifier.</param>
        /// <param name="timestamp">The timestamp.</param>
        public ClickEvent(Guid definitionId, DateTime timestamp) : base(definitionId, timestamp)
        {
        }
    }
}