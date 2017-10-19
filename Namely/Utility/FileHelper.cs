using System.IO;
using Namely.Core.Interface;
using Xamarin.Forms;
using Namely;

[assembly: Dependency(typeof(FileHelper))]
namespace Namely
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}