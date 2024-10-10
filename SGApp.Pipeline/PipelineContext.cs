namespace SGApp.Pipeline
{
    internal class PipelineContext : IPipelineContext
    {
        public IPipelineDataCollection Data { get; }
        public PipelineContext()
        {
            Data = new PipelineDataCollection();
        }
    }
}