using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentCourse.Startup))]
namespace StudentCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
