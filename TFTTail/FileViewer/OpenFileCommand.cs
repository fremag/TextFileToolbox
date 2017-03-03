using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UITools.ToolBar;

namespace TFT.Tail.FileViewer
{
    public class OpenFileCommand : AbstractVoidUICommand
    {
        public OpenFileCommand() : base("Open", "Open some files...", UIToolBarSettings.Main.Name, Properties.Resources.folder_go)
        {
        }

        public override void Run()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if(dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var files = dialog.FileNames;
            MessageBus.SendMessage(new DisplayFilesRequest(files));
        }
    }
}
