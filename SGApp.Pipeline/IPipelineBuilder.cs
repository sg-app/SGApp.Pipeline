namespace SGApp.Pipeline
{
    public interface IPipelineBuilder
    {
        IPipelineBuilder<TRequest> For<TRequest>();
    }

    public interface IPipelineBuilder<TRequest>
    {
        IPipelineBuilder<TRequest> WithHandler<THandler>()
            where THandler : IPipelineStepHandler<TRequest>;
        IPipelineBuilder<TRequest> WithHandler(Type type);

        IPipeline<TRequest> Build();
    }
}
