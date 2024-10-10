using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGApp.Pipeline.Tests.Data
{
    public class FakeHandler1 : IPipelineStepHandler<FakeDataForPipeline>
    {
        public Task HandleAsync(FakeDataForPipeline request, IPipelineContext chainContext, CancellationToken cancellationToken = default)
        {
            request.MessageLog.Add("FakeHandler1");
            return Task.CompletedTask;
        }
    }

    public class FakeHandler2 : IPipelineStepHandler<FakeDataForPipeline>
    {
        public Task HandleAsync(FakeDataForPipeline request, IPipelineContext chainContext, CancellationToken cancellationToken = default)
        {
            request.MessageLog.Add("FakeHandler2");
            return Task.CompletedTask;
        }
    }

    public class FakeHandler3 : IPipelineStepHandler<FakeDataForPipeline>
    {
        public Task HandleAsync(FakeDataForPipeline request, IPipelineContext chainContext, CancellationToken cancellationToken = default)
        {
            request.MessageLog.Add("FakeHandler3");
            return Task.CompletedTask;
        }
    }
}
