namespace SGApp.Pipeline
{
    public interface IPipeline<TRequest>
    {
        /// <summary>
        /// Runs the chain of responsibilities pipeline
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns></returns>
        Task RunAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}