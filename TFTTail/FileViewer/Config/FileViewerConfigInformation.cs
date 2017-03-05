namespace TFT.Tail.FileViewer.Config
{
    public class FileViewerConfigInformation : AbstractFileViewerConfigInformation
    {
        public FileViewerConfig FileViewerConfig { get; private set; }
        public FileViewerConfigInformation(FileViewerConfig config) : base(config)
        {
            FileViewerConfig = config;
        }

        public override string Name => FileViewerConfig.Name;
        public override string Description => $"Filters: {FileViewerConfig.Filters.Count}";
    }
}
