using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCoreTestWebAPI.Models;
using WorkflowCoreTestWebAPI.WorkFlows;

namespace WorkflowCoreTestWebAPI
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
            services.AddLogging();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddWorkflow();

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Workflow test API", Version = "v1" });
                    c.CustomSchemaIds(x => x.FullName);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workflow test API V1"));

            var host = app.ApplicationServices.GetService<IWorkflowHost>();

            //host.RegisterWorkflow<AskForLeaveWorkflow, WorkflowData>();
            var loader = app.ApplicationServices.GetService<IDefinitionLoader>();
            loader.LoadDefinition(WorkflowJsons.GetWorkflowJsons());

            host.Start();
        }
    }
}
