using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace xConnect.HeatMap.Processors
{
    /// <summary>
    /// Register routes
    /// </summary>
    public class RegisterRoutes
    {
        /// <summary>
        /// Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public virtual void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute("HeatMap", "api/heatmap/{controller}/{action}");
        }
    }
}