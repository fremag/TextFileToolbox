using System.Collections.Generic;
using WinFwk.UIMessages;

namespace TFT.Tail.FileViewer
{
    public class DisplayFilesRequest : AbstractUIMessage
    {
        public IEnumerable<string> FilePaths { get; }
        public DisplayFilesRequest(IEnumerable<string> filePaths) 
        {
            FilePaths = filePaths;
        }
    }
}
