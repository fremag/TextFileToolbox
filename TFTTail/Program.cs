using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFwk.UITools.Settings;

namespace TFT.Tail
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UISettingsMgr<TailSettings>.Init(Application.ProductName);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TFT_TailForm());
        }
    }
}
