using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniLearningSystem.Startup))]
namespace MiniLearningSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
