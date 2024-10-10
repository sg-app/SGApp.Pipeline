namespace SGApp.Pipeline
{
    public interface IPipelineContext
    {
        /// <summary>
        /// Gets the data available on this pipeline.
        /// </summary>
        IPipelineDataCollection Data { get; }
    }
}