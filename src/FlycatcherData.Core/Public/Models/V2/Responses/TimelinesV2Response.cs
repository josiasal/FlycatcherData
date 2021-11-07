using Newtonsoft.Json;

using Tweetinvi.Models.V2;

namespace FlycatcherData.Models.V2
{
    public class TimelinesV2Response
    {
        /// <summary>
        /// Tweets returned by the request
        /// </summary>
        [JsonProperty("data")] public TweetV2[] Tweets { get; set; } = new TweetV2[0];

        /// <summary>
        /// Contains all the requested expansions
        /// </summary>
        [JsonProperty("includes")] public TweetIncludesV2 Includes { get; set; }

        /// <summary>
        /// All errors that prevented Twitter to send some data,
        /// but which did not prevent the request to be resolved.
        /// </summary>
        [JsonProperty("errors")] public ErrorV2[] Errors { get; set; }

        /// <summary>
        /// This object contains information about the number of users 
        /// returned in the current request and pagination details.
        /// </summary>
        [JsonProperty("meta")] public TweetMetaV2 Meta { get; set; }
    }
}
