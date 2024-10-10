using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SGApp.Pipeline.Tests.Data;


namespace SGApp.Pipeline.Tests
{
    public class PipelineTests
    {
        [Test]
        public async Task PipelineBuilder_BuildPipeline()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddTransient<FakeHandler1>()
                .AddTransient<FakeHandler2>()
                .AddTransient<FakeHandler3>()
                .BuildServiceProvider();

            var pipeline = new PipelineBuilder(serviceProvider)
                .For<FakeDataForPipeline>()
                .WithHandler<FakeHandler1>()
                .WithHandler<FakeHandler2>()
                .WithHandler<FakeHandler3>()
                .Build();

            var request = new FakeDataForPipeline();

            // Act
            await pipeline.RunAsync(request);

            // Assert
            request.MessageLog.Should().HaveCount(3);
            request.MessageLog[0].Should().Be("FakeHandler1");
            request.MessageLog[1].Should().Be("FakeHandler2");
            request.MessageLog[2].Should().Be("FakeHandler3");

        }

        [Test]
        public async Task Pipeline_should_call_with_handler_type()
        {
            // Arrange
            var assembly = typeof(FakeHandler1).Assembly;
            var typeNames = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IPipelineStepHandler<FakeDataForPipeline>)))
                .Select(f=>f.FullName);

            var serviceProvider = new ServiceCollection()
                .AddTransient<FakeHandler1>()
                .AddTransient<FakeHandler2>()
                .AddTransient<FakeHandler3>()
                .BuildServiceProvider();

            var builder = new PipelineBuilder(serviceProvider)
                .For<FakeDataForPipeline>();

            foreach (var typeName in typeNames ?? [])
            {
                if(typeName is null)
                    continue;

                if (Type.GetType(typeName) is Type t)
                    builder.WithHandler(t);
            }
            var pipeline = builder.Build();
            var request = new FakeDataForPipeline();

            // Act
            await pipeline.RunAsync(request);

            // Assert
            request.MessageLog.Should().HaveCount(3);
            request.MessageLog[0].Should().Be("FakeHandler1");
            request.MessageLog[1].Should().Be("FakeHandler2");
            request.MessageLog[2].Should().Be("FakeHandler3");

        }
    }
}
