namespace SGApp.Pipeline
{
    public class PipelineBuilder : IPipelineBuilder
    {
        private readonly IServiceProvider _serviceProvider;

        public PipelineBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPipelineBuilder<TRequest> For<TRequest>()
        {
            return new PipelineBuilder<TRequest>(_serviceProvider);
        }
    }

    public class PipelineBuilder<TRequest> : IPipelineBuilder<TRequest>
    {
        private readonly List<Type> _handlerTypes = [];
        private readonly IServiceProvider _serviceProvider;

        public PipelineBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPipelineBuilder<TRequest> WithHandler<THandler>() where THandler : IPipelineStepHandler<TRequest>
        {
            _handlerTypes.Add(typeof(THandler));
            return this;
        }

        public IPipelineBuilder<TRequest> WithHandler(Type type)
        {
            if (typeof(IPipelineStepHandler<TRequest>).IsAssignableFrom(type))
                _handlerTypes.Add(type);
            return this;
        }

        public IPipeline<TRequest> Build()
        {
            return new Pipeline<TRequest>(_serviceProvider, _handlerTypes);
        }

    }
}
