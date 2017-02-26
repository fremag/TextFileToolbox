using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TFT.Tail.FileRepository;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIModules;
using WinFwk.UIServices;

namespace TFT.Tail
{
    public partial class TFT_TailForm : UIModuleForm
    {
        public TFT_TailForm()
        {
            InitializeComponent();
        }

        private void TFT_TailForm_Load(object sender, EventArgs e)
        {
            InitModuleFactory();
            UIServiceHelper.InitServices(msgBus);
            InitToolBars();
            InitLog();

            var workContent = InitWorkplace();
            UIModuleFactory.CreateModule<FileRepositoryModule>(module => { }, module => DockModule(module, workContent, DockAlignment.Bottom));
        }


        private void MemoScopeForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MemoScopeForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var fileInfos = files.Select(filePath => new FileInfo(filePath)).ToArray();
            var folders = fileInfos.Where(fi => fi.Attributes.HasFlag(FileAttributes.Directory)).Select(fi => fi.FullName);
            var fileFolders = fileInfos.Where(fi => ! fi.Attributes.HasFlag(FileAttributes.Directory)).Select(fi => fi.Directory.FullName);
            var allFolders = folders.Concat(fileFolders).Distinct();
            foreach (var folder in allFolders)
            {
                msgBus.SendMessage(new CreateRepositoryFolderRequest(folder, "*.*"));
            }
        }

    }
}
