using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileUploadWeb.Startup))]
namespace FileUploadWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
