using WinFwk.UIMessages;

namespace TFT.Tail.FileRepository
{
    public class CreateRepositoryFolderRequest : AbstractUIMessage
    {
        public string Path { get; }
        public string Pattern { get; } = "*.*";
        public CreateRepositoryFolderRequest(string path, string pattern)
        {
            Path = path;
            Pattern = pattern;
        }
    }
}