using WinFwk.UICommands;

namespace TFT.Tail.FileViewer.Commands
{
    public class StartFileViewerCommand : AbstractTypedUICommand<FileViewerModule>
    {
        public StartFileViewerCommand() : base("Start", "Start FileViewer", "Tail", Properties.Resources.control_play_blue)
        {
        }

        public override void HandleAction(FileViewerModule fileViewerModule)
        {
            fileViewerModule.Start();
        }
    }
}
