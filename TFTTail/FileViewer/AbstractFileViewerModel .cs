using BrightIdeasSoftware;
using TFT.Tail.Core;

namespace TFT.Tail.FileViewer
{
    public abstract class AbstractFileViewerModel : AbstractVirtualListDataSource
    {
        protected FileIndexer fileIndexer;

        public AbstractFileViewerModel(VirtualObjectListView listView, FileIndexer fileIndexer) : base(listView)
        {
            this.fileIndexer = fileIndexer;
        }

        public override object GetNthObject(int n)
        {
            var line = fileIndexer.ReadLine(n);
            return new object[] { n, line };
        }

        public override int GetObjectCount()
        {
            return fileIndexer.Count;
        }
    }
}
