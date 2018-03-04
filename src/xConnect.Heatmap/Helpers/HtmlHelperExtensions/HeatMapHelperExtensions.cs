using Sitecore.Mvc.Helpers;
using System.Web;

namespace xConnect.HeatMap.Helpers.HtmlHelperExtensions
{
    /// <summary>
    /// Heat Map Helper Extensions
    /// </summary>
    public static class HeatMapHelperExtensions
    {
        /// <summary>
        /// Heats the map header.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <returns>The required header for heat map</returns>
        public static HtmlString HeatMapHeader(this SitecoreHelper helper)
        {
            return helper.ViewRendering("~/Views/HeatMap/HeatMapHeader.cshtml");
        }
    }
}