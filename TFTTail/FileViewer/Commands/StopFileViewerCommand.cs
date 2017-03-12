using WinFwk.UICommands;

namespace TFT.Tail.FileViewer.Commands
{
    public class StopFileViewerCommand : AbstractTypedUICommand<FileViewerModule>
    {
        public StopFileViewerCommand() : base("Stop", "Stop FileViewer", "Tail", Properties.Resources.control_stop_blue)
        {
        }

        public override void HandleAction(FileViewerModule fileViewerModule)
        {
            fileViewerModule.Stop();
        }
    }
}
