namespace SGApp.Pipeline
{
    internal class PipelineDataCollection : IPipelineDataCollection
    {
        private readonly Dictionary<string, object> _data = [];
        public TItem? Get<TItem>(string key)
        {
            if (_data.TryGetValue(key, out object? value))
            {
                return (TItem)value;
            }

            return default;
        }

        public void Set<TItem>(string key, TItem instance)
        {
            _data[key] = instance ?? throw new ArgumentNullException(nameof(instance));
        }

        public bool ContainsKey(string key) => _data.ContainsKey(key);
    }
}