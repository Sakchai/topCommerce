using System.Threading.Tasks;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Api
{
    public interface IApiPlugin
    {
        string GetConfigurationPageUrl();
        Task InstallAsync();
        Task ManageSiteMapAsync(SiteMapNode rootNode);
        Task UninstallAsync();
    }
}