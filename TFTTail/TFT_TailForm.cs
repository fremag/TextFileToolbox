using System;
using WinFwk.UIModules;

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
            InitToolBars();
            InitWorkplace();
            InitLog();
        }
    }
}
