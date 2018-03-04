using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using xConnect.HeatMap.Services;

namespace xConnect.HeatMap.Controllers
{
    /// <summary>
    /// The heat map controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HeatMapController : Controller
    {
        /// <summary>
        /// The heat map collector service
        /// </summary>
        private readonly IHeatMapCollectorService heatMapCollectorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        /// <returns></returns>
        public HeatMapController()
        {
            this.heatMapCollectorService = new HeatMapCollectorService();
        }

        /// <summary>
        /// Clicks the specified page identifier.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <param name="componentId">The component identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>Async void task</returns>
        public async Task Click(Guid pageId, Guid componentId, string language)
        {
            await this.heatMapCollectorService.ClickAsync(pageId, componentId, language);
        }

        /// <summary>
        /// Gets the clicks.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>Async action</returns>
        public async Task<ActionResult> GetClicks(Guid pageId, string language)
        {
            var clicks = await this.heatMapCollectorService.GetClicksAsync(pageId, language);
            return Json(clicks, JsonRequestBehavior.AllowGet);
        }
    }
}