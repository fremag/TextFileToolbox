using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UITools;

namespace TFT.Tail.FileRepository
{
    public abstract class AbstractFileRepositoryInformation : TreeNodeInformationAdapter<AbstractFileRepositoryInformation>
    {
        [OLVColumn(Width = 150, ImageAspectName = nameof(Icon))]
        public string Name { get; protected set; }
        [IntColumn(Title = "Size (Mo)", Width = 50)]
        public abstract long Size { get; }
        public Image Icon { get; protected set; }

        [OLVColumn(Title = "Date", Width = 150, TextAlign = HorizontalAlignment.Center, AspectToStringFormat = "{0:yyyy/MM/dd HH:mm:ss}")]
        public abstract DateTime? ModificationDate { get; }
        [OLVColumn(Title = "Date", Width = 150, TextAlign = HorizontalAlignment.Center, AspectToStringFormat = "{0:yyyy/MM/dd HH:mm:ss}")]
        public abstract DateTime? CreationDate { get; }
        public abstract string Path { get; }
    }
}