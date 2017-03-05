using System.Collections.Generic;
using System.ComponentModel;
using TFT.Tail.Core;
using WinFwk.UITools.Configuration;

namespace TFT.Tail.FileViewer.Config
{
    public class FileViewerConfig : ModuleConfigAdapter, IIdentifiable
    {
        public string Name { get; set; }
        public FilterMode FilterMode { get; set; }
        public List<RegexConfig> Filters { get; set; } = new List<RegexConfig>();

        [Browsable(false)]
        public int Id { get; set; }
    }
}
