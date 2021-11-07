using System.Threading.Tasks;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Web;
using Tweetinvi;
using Tweetinvi.Client;

using FlycatcherData.Models.V2;
using FlycatcherData.Parameters.V2;
using FlycatcherData.Core.Controllers.V2;

namespace FlycatcherData.Client.Requesters.V2
{
    public class TimelinesV2Requester : BaseRequester, ITimelinesV2Requester
    {
        private readonly ITimelinesV2Controller _timelinesV2Controller;

        public TimelinesV2Requester(
            ITwitterClient client,
            ITwitterClientEvents twitterClientEvents,
            ITimelinesV2Controller timelinesV2Controller) : base(client, twitterClientEvents)
        {
            _timelinesV2Controller = timelinesV2Controller;
        }

        public ITwitterPageIterator<ITwitterResult<TimelinesV2Response>, string> GetUserTweetsTimelineIterator(IGetTimelinesV2Parameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _timelinesV2Controller.GetUserTweetsTimelineIterator(parameters, request);
        }

        public ITwitterPageIterator<ITwitterResult<TimelinesV2Response>, string> GetUserMentionedTimelineIterator(IGetTimelinesV2Parameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _timelinesV2Controller.GetUserMentionedTimelineIterator(parameters, request);
        }
    }
}
