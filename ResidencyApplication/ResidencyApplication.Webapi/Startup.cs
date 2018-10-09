using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResidencyApplication.Repository.ResidencyApplication;

namespace ResidencyApplication.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<ResidencyApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ResidencyAppdbConnString")));
            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ApplicantModel>("Applicants").EntityType.Filter(QueryOptionSetting.Allowed);
            app.UseCors(options => options
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin()
                                    .AllowCredentials()

                                    );

            app.UseMvc(b =>
            {
                b.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
                b.EnableDependencyInjection();
                b.Select()
                .Expand()
                .Filter()
                .OrderBy(QueryOptionSetting.Allowed)
                .MaxTop(2000)
                .Count();


            });
        }
    }
}
