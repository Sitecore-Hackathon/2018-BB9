using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(xConnect.HeatMap.RazorGeneratorMvcStart), "Start")]

namespace xConnect.HeatMap
{
    /// <summary>
    /// Razor generator MVC start
    /// </summary>
    public static class RazorGeneratorMvcStart
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public static void Start()
        {
            var engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly)
            {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
            };

            ViewEngines.Engines.Insert(0, engine);

            // StartPage lookups are done by WebPages. 
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }
    }
}
