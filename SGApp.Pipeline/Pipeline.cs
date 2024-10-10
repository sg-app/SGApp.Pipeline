namespace SGApp.Pipeline
{
    internal class Pipeline<TRequest> : IPipeline<TRequest>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<Type> _handlerTypes;

        public Pipeline(IServiceProvider serviceProvider, IEnumerable<Type> handlerTypes)
        {
            _serviceProvider = serviceProvider;
            _handlerTypes = handlerTypes;
        }

        public async Task RunAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            var pipelineContext = new PipelineContext();

            foreach (var handlerType in _handlerTypes)
            {
                var handler = _serviceProvider.GetService(handlerType) as IPipelineStepHandler<TRequest>
                    ?? throw new InvalidOperationException($"Handler {handlerType.Name} not found");

                await handler.HandleAsync(request, pipelineContext, cancellationToken);
            }
        }
    }
}
