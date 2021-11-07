using Tweetinvi.Core.Injectinvi;

using FlycatcherData.Client.V2;
using FlycatcherData.Client.Requesters.V2;

namespace FlycatcherData
{
    public class FlycatcherDataModule : ITweetinviModule
    {
        /// <summary>
        /// Initialize the module registration.
        /// </summary>
        public void Initialize(ITweetinviContainer container)
        {
            container.RegisterType<ITimelinesV2Client, TimelinesV2Client>();
            container.RegisterType<ITimelinesV2Requester, TimelinesV2Requester>();
        }
    }
}
