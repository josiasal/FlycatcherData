using Tweetinvi.Core.Injectinvi;

using FlycatcherData.Core.Controllers.V2;
using FlycatcherData.Controllers.Timeline;
using FlycatcherData.Core.QueryGenerators.V2;

namespace FlycatcherData.Controllers
{
    public class FlycatcherDataControllersModule : ITweetinviModule
    {
        public void Initialize(ITweetinviContainer container)
        {
            InitializeControllers(container);
            InitializeQueryExecutors(container);
            InitializeQueryGenerators(container);
        }

        private void InitializeControllers(ITweetinviContainer container)
        {
            container.RegisterType<ITimelinesV2Controller, TimelinesV2Controller>();
        }

        private void InitializeQueryExecutors(ITweetinviContainer container)
        {
            container.RegisterType<ITimelinesV2QueryExecutor, TimelinesV2QueryExecutor>();
        }

        private void InitializeQueryGenerators(ITweetinviContainer container)
        {
            container.RegisterType<ITimelinesV2QueryGenerator, TimelinesV2QueryGenerator>();
        }
    }
}