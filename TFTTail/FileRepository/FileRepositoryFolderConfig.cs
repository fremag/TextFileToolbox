using System.ComponentModel;
using System.Xml.Serialization;
using WinFwk.UITools.Configuration;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryFolderConfig : IModuleConfig
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }
        public string Pattern { get; set; } = "*.*";

        [XmlIgnore]
        [Browsable(false)]
        public IConfigurableModule OwnerModule { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}