using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace TFT.Tail.FileRepository
{

    public class FileRepositoryCommand : AbstractVoidUICommand
    {
        public FileRepositoryCommand() : base("Explorer", "Display explorer", UIToolBarSettings.Main.Name, Properties.Resources.file_manager, Keys.Control | Keys.Shift | Keys.F)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<FileRepositoryModule>(module => { }, module => DockModule(module, DockState.DockLeft));
        }
    }
}
