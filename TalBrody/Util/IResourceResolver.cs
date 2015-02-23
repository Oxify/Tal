using Castle.MicroKernel.Registration;

namespace TalBrody.Util
{
    public interface IResourceResolver
    {
        string Resolve(string path);
    }
}