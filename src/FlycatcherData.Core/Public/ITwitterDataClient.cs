using Tweetinvi;

using FlycatcherData.Client.V2;

namespace FlycatcherData
{
    public interface ITwitterDataClient : ITwitterClient
    {
        ITimelinesV2Client TimelinesV2 { get; }
    }
}
