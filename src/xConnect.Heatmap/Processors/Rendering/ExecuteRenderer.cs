using System.IO;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;

namespace xConnect.HeatMap.Processors.Rendering
{
    /// <summary>
    /// Heat map execute renderer
    /// </summary>
    /// <seealso cref="Sitecore.Mvc.Pipelines.Response.RenderRendering.ExecuteRenderer" />
    public class HeatMapExecuteRenderer : ExecuteRenderer
    {
        /// <summary>
        /// Renders the specified renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="writer">The writer.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>Rendered</returns>
        protected override bool Render(Renderer renderer, TextWriter writer, RenderRenderingArgs args)
        {
            if (Sitecore.Context.Database.Name == "web" && Sitecore.Context.PageMode.IsNormal)
            {
                writer.WriteLine($"<code uniqueid=\"{args.Rendering.UniqueId}\"></code>");
            }

            return base.Render(renderer, writer, args);
        }
    }
}