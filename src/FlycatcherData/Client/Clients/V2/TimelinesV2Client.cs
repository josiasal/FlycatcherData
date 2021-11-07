using System;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherData.Client.Requesters.V2;
using FlycatcherData.Models.V2;
using FlycatcherData.Parameters.V2;


namespace FlycatcherData.Client.V2
{
    public class TimelinesV2Client : ITimelinesV2Client
    {
        private readonly ITimelinesV2Requester _timelinesV2Requester;

        public TimelinesV2Client(ITimelinesV2Requester timelinesV2Requester)
        {
            _timelinesV2Requester = timelinesV2Requester;
        }

        public ITwitterRequestIterator<TimelinesV2Response, string> GetUserTweetsTimelineIterator(IGetTimelinesV2Parameters parameters)
        {
            var iterator = _timelinesV2Requester.GetUserTweetsTimelineIterator(parameters);

            return new IteratorPageProxy<ITwitterResult<TimelinesV2Response>, TimelinesV2Response, string>(iterator, input => input.Model);
        }

        public ITwitterRequestIterator<TimelinesV2Response, string> GetUserMentionedTimelineIterator(IGetTimelinesV2Parameters parameters)
        {
            var iterator = _timelinesV2Requester.GetUserMentionedTimelineIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<TimelinesV2Response>, TimelinesV2Response, string>(iterator, input => input.Model);
        }
    }
}
