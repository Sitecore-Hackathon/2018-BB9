using Sitecore.XConnect.Schema;
using xConnect.HeatMap.Models.Models;

namespace xConnect.HeatMap.Models.Builders
{
    /// <summary>
    /// The model builder
    /// </summary>
    public class ModelBuilder
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public static XdbModel Model { get; } = BuildModel();

        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <returns>The xdb model</returns>
        private static XdbModel BuildModel()
        {
            XdbModelBuilder modelBuilder = new XdbModelBuilder("HeatMapModel", new XdbModelVersion(1, 0));
            modelBuilder.DefineEventType<ClickEvent>(false);
            return modelBuilder.BuildModel();
        }
    }
}