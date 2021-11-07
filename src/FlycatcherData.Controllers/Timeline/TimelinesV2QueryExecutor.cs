using System.Threading.Tasks;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherData.Models.V2;
using FlycatcherData.Parameters.V2;
using FlycatcherData.Core.QueryGenerators.V2;

namespace FlycatcherData.Controllers.Timeline
{
    public interface ITimelinesV2QueryExecutor
    {
        Task<ITwitterResult<TimelinesV2Response>> GetUserTweetsTimelineAsync(IGetTimelinesV2Parameters parameters, ITwitterRequest request);
        Task<ITwitterResult<TimelinesV2Response>> GetUserMentionedTimelineAsync(IGetTimelinesV2Parameters parameters, ITwitterRequest request);
    }

    public class TimelinesV2QueryExecutor : ITimelinesV2QueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly ITimelinesV2QueryGenerator _timelinesQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public TimelinesV2QueryExecutor(
            JsonContentFactory jsonContentFactory,
            ITimelinesV2QueryGenerator timelinesQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _timelinesQueryGenerator = timelinesQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<TimelinesV2Response>> GetUserTweetsTimelineAsync(IGetTimelinesV2Parameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _timelinesQueryGenerator.GetTimelineQuery(parameters);
            request.Query.HttpMethod = HttpMethod.GET;
            return _twitterAccessor.ExecuteRequestAsync<TimelinesV2Response>(request);
        }
        public Task<ITwitterResult<TimelinesV2Response>> GetUserMentionedTimelineAsync(IGetTimelinesV2Parameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _timelinesQueryGenerator.GetMentionTimelineQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<TimelinesV2Response>(request);
        }
    }
}
