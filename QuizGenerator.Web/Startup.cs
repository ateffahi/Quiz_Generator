using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizGenerator.Web.Startup))]
namespace QuizGenerator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
