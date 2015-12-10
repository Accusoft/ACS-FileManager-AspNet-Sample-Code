namespace NancyApplication
{
    using Microsoft.AspNet.Builder;
    using Nancy.Owin;
    
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Nancy default port is 5000
            app.UseOwin(x => x.UseNancy());
        }
    }
}
