using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Core.Injectinvi;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Client;
using Tweetinvi.Core.RateLimit;
using Tweetinvi.Events;

using FlycatcherData.Client.V2;
using FlycatcherData.Controllers;

namespace FlycatcherData
{
    public class TwitterDataClient : TwitterClient, ITwitterDataClient
    {
        private readonly ITweetinviContainer _tweetinviContainer;
        private readonly ITwitterClientEvents _twitterClientEvents;

        public TwitterDataClient(ReadOnlyTwitterCredentials credentials) : this(credentials, new TwitterClientParameters())
        {
        }

        public TwitterDataClient(string consumerKey, string consumerSecret) : this(new ReadOnlyTwitterCredentials(consumerKey, consumerSecret), new TwitterClientParameters())
        {
        }

        public TwitterDataClient(string consumerKey, string consumerSecret, string bearerToken) : this(new ReadOnlyTwitterCredentials(consumerKey, consumerSecret, bearerToken), new TwitterClientParameters())
        {
        }

        public TwitterDataClient(string consumerKey, string consumerSecret, string accessToken, string accessSecret) : this(new ReadOnlyTwitterCredentials(consumerKey, consumerSecret, accessToken, accessSecret), new TwitterClientParameters())
        {
        }

        public TwitterDataClient(IReadOnlyTwitterCredentials credentials, TwitterClientParameters parameters) : base(credentials, parameters)
        {
            RegisterCustomModules();

            _tweetinviContainer = new Tweetinvi.Injectinvi.TweetinviContainer(Tweetinvi.TweetinviContainer.Container);
            _tweetinviContainer.RegisterInstance(typeof(TwitterDataClient), this);
            _tweetinviContainer.RegisterInstance(typeof(ITwitterClient), this);
            _tweetinviContainer.AssociatedClient = this;
            
            void BeforeRegistrationDelegate(object sender, TweetinviContainerEventArgs args)
            {
                parameters?.RaiseBeforeRegistrationCompletes(args);
            }

            _tweetinviContainer.BeforeRegistrationCompletes += BeforeRegistrationDelegate;
            _tweetinviContainer.Initialize();
            _tweetinviContainer.BeforeRegistrationCompletes -= BeforeRegistrationDelegate;

            _twitterClientEvents = _tweetinviContainer.Resolve<ITwitterClientEvents>();

            var rateLimitCacheManager = _tweetinviContainer.Resolve<IRateLimitCacheManager>();
            rateLimitCacheManager.RateLimitsClient = RateLimits;

            TimelinesV2 = _tweetinviContainer.Resolve<ITimelinesV2Client>();
        }

        private void RegisterCustomModules()
        {
            Tweetinvi.TweetinviContainer.AddModule(new FlycatcherDataModule());
            Tweetinvi.TweetinviContainer.AddModule(new FlycatcherDataControllersModule());
        }

        public ITimelinesV2Client TimelinesV2 { get; }
        
        new public ITwitterExecutionContext CreateTwitterExecutionContext()
        {
            return new TwitterExecutionContext
            {
                RequestFactory = CreateRequest,
                Container = _tweetinviContainer,
                Events = _twitterClientEvents
            };
        }
    }
}
