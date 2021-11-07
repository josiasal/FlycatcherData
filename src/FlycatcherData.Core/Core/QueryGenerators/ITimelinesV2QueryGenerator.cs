using System.Text;

using FlycatcherData.Parameters.V2;

namespace FlycatcherData.Core.QueryGenerators.V2
{
    public interface ITimelinesV2QueryGenerator
    {
        string GetTimelineQuery(IGetTimelinesV2Parameters parameters);
        string GetMentionTimelineQuery(IGetTimelinesV2Parameters parameters);
        void AddTimelineFieldsParameters(IGetTimelinesV2Parameters parameters, StringBuilder query);
    }
}
