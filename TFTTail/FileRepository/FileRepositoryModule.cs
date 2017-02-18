using WinFwk.UIModules;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryModule : UIModule
    {
        public override void Init()
        {
            this.Name = "File Repository";
            this.Text = "File Repository";
            this.Summary = "File Repository";
            this.Icon = Properties.Resources.file_manager_small; 
        }
    }
}
