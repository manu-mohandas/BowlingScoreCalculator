using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ScoreCalculator.Infrastructure.Filters;
using ScoreCalculator.Services;
using ScoreCalculator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;
using ScoreCalculator.Model;

namespace ScoreCalculator
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ApiExceptionFilterAtrribute());
                options.Filters.Add(new BasicAuthenticationFilter());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddFluentValidation();

            services.AddScoped<IValidator<BowlingScoreRequest>, BowlingScoreRequestValidator>();
            services.AddScoped(typeof(IBowlingScoreServices), typeof(BowlingScoreServices));
            services.AddScoped(typeof(IBowlingGame), typeof(BowlingGame));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
