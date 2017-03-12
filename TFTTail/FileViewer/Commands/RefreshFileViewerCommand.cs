using WinFwk.UICommands;

namespace TFT.Tail.FileViewer.Commands
{
    public class RefreshFileViewerCommand : AbstractTypedUICommand<FileViewerModule>
    {
        public RefreshFileViewerCommand() : base("Refresh", "Refresh FileViewer", "Tail", Properties.Resources.table_refresh)
        {
        }

        public override void HandleAction(FileViewerModule fileViewerModule)
        {
            fileViewerModule.RefreshFileViewer();
        }
    }
}
