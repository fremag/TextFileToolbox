using System.Windows.Forms;
using BrightIdeasSoftware;
using TFT.Tail.Core;

namespace TFT.Tail.FileViewer
{
    public class DefaultFileViewerModel : AbstractFileViewerModel
    {
        public DefaultFileViewerModel(VirtualObjectListView listView, FileIndexer fileIndexer) : base(listView, fileIndexer)
        {
            var colNumLine = new OLVColumn("#", null);
            colNumLine.AspectToStringFormat = "{0:###,###,###,##0}";
            colNumLine.TextAlign = HorizontalAlignment.Right;

            colNumLine.AspectGetter = o => ((object[])o)[0];
            listView.Columns.Add(colNumLine);
            var colText = new OLVColumn("text", null);
            colText.FillsFreeSpace = true;
            colText.AspectGetter = o => ((object[])o)[1];
            listView.Columns.Add(colText);
        }
    }
}
