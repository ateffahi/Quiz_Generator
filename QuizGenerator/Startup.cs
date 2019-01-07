using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizGenerator.Startup))]
namespace QuizGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
