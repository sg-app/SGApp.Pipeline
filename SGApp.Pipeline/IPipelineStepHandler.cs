namespace SGApp.Pipeline
{
    public interface IPipelineStepHandler { }
    public interface IPipelineStepHandler<in TRequest> : IPipelineStepHandler
    {
        Task HandleAsync(TRequest request, IPipelineContext chainContext, CancellationToken cancellationToken = default);
    }
}