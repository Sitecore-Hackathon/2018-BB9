using Sitecore.XConnect.Serialization;
using xConnect.HeatMap.Models.Builders;

namespace xConnect.HeatMap.Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = XdbModelWriter.Serialize(ModelBuilder.Model);
        }
    }
}
