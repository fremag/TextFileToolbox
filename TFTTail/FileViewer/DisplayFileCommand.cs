using WinFwk.UICommands;
using WinFwk.UITools.ToolBar;

namespace TFT.Tail.FileViewer
{
    public class DisplayFileCommand : AbstractDataUICommand<DisplayFilesRequest>
    {
        public DisplayFileCommand() : base("Display", "Display selected files", UIToolBarSettings.Main.Name, Properties.Resources.document_inspect)
        {
        }

        protected override void HandleData(DisplayFilesRequest displayFilesRequest)
        {
            MessageBus.SendMessage(displayFilesRequest);
        }
    }
}
