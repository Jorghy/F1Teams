using F1TestApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace F1TestApp
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
            services.AddDbContext<TeamContext>(opt => opt.UseInMemoryDatabase(databaseName: "F1TeamsDB"));

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            AddTestData();
        }

        private void AddTestData()
        {
            var options = new DbContextOptionsBuilder<TeamContext>()
                .UseInMemoryDatabase(databaseName: "F1TeamsDB")
                .Options;

            using(var context = new TeamContext(options))
            {
                Team team1 = new Team
                {
                    ID = 1,
                    Name = "Ferrari",
                    YearOfEstablishment = "1994",
                    NumberOfWon = 20,
                    IsPaidEntryFee = true
                };
                context.Teams.Add(team1);

                Team team2 = new Team
                {
                    ID = 2,
                    Name = "McLaren",
                    YearOfEstablishment = "1989",
                    NumberOfWon = 15,
                    IsPaidEntryFee = true
                };
                context.Teams.Add(team2);

                Team team3 = new Team
                {
                    ID = 3,
                    Name = "Mercedes",
                    YearOfEstablishment = "1990",
                    NumberOfWon = 18,
                    IsPaidEntryFee = true
                };
                context.Teams.Add(team3);

                context.SaveChanges();
            }
        }
    }
}
