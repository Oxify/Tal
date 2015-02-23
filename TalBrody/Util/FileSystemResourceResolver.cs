using System.Web;

namespace TalBrody.Util
{
    public class FileSystemResourceResolver : IResourceResolver
    {
        private readonly string _templateLocation;

        public FileSystemResourceResolver(string templateLocation)
        {
            _templateLocation = templateLocation;
        }

        public string Resolve(string path)
        {
            return System.IO.File.ReadAllText(_templateLocation + path);
        }

    }
}