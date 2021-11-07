using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherData.Models.V2;
using FlycatcherData.Parameters.V2;

namespace FlycatcherData.Core.Controllers.V2
{
    public interface ITimelinesV2Controller
    {
        ITwitterPageIterator<ITwitterResult<TimelinesV2Response>, string> GetUserTweetsTimelineIterator(IGetTimelinesV2Parameters parameters, ITwitterRequest request);
        ITwitterPageIterator<ITwitterResult<TimelinesV2Response>, string> GetUserMentionedTimelineIterator(IGetTimelinesV2Parameters parameters, ITwitterRequest request);
    }
}
