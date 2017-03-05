using System.Drawing;
using BrightIdeasSoftware;
using WinFwk.UITools;

namespace TFT.Tail.FileViewer.Config
{
    public abstract class AbstractFileViewerConfigInformation : TreeNodeInformationAdapter<AbstractFileViewerConfigInformation>
    {
        [OLVColumn(Width = 250, ImageAspectName = nameof(Icon))]
        public virtual string Name { get; }
        [OLVColumn(Width = 500)]
        public virtual string Description { get; }

        public Image Icon { get; protected set; }

        public object Data { get; }

        public AbstractFileViewerConfigInformation(object data)
        {
            Data = data;
        }
    }
}
