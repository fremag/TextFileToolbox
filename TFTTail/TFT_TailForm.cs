using System;
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
            InitWorkplace();
            InitLog();
        }
    }
}
