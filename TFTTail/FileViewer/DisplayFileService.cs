using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UIServices;

namespace TFT.Tail.FileViewer
{
    public class DisplayFileService : AbstractUIService
        , IMessageListener<DisplayFilesRequest>
    {
        public void HandleMessage(DisplayFilesRequest message)
        {
            foreach (var file in message.FilePaths) {
                UIModuleFactory.CreateModule<FileViewerModule>(mod => mod.Setup(file));
            }
        }
    }
}
