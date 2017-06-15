using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDbContext<SeatContext>(options => options.UseSqlite("Data Source=seats.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SeatContext context)
        {
            context.Database.EnsureCreated();

            List<Seat> seats = new List<Seat>();
            Seat g0 = new Seat();
            g0.SeatCode = "g0";
            g0.OccName = "Barack Obama";
            g0.OccAuth = "Groom";
            g0.Reserved = true;
            seats.Add(g0);
            Seat b0 = new Seat();
            b0.SeatCode = "b0";
            b0.OccName = "Michelle Obama";
            b0.OccAuth = "Bride";
            b0.Reserved = true;
            seats.Add(b0);
            Seat g1 = new Seat();
            g1.SeatCode = "g1";
            g1.OccName = "";
            g1.OccAuth = "";
            g1.Reserved = false;
            seats.Add(g1);
            Seat g2 = new Seat();
            g2.SeatCode = "g2";
            g2.OccName = "";
            g2.OccAuth = "";
            g2.Reserved = false;
            seats.Add(g2);
            Seat g3 = new Seat();
            g3.SeatCode = "g3";
            g3.OccName = "";
            g3.OccAuth = "";
            g3.Reserved = false;
            seats.Add(g3);
            Seat g4 = new Seat();
            g4.SeatCode = "g4";
            g4.OccName = "";
            g4.OccAuth = "";
            g4.Reserved = false;
            seats.Add(g4);
            Seat g5 = new Seat();
            g5.SeatCode = "g5";
            g5.OccName = "";
            g5.OccAuth = "";
            g5.Reserved = false;
            seats.Add(g5);
            Seat g6 = new Seat();
            g6.SeatCode = "g6";
            g6.OccName = "";
            g6.OccAuth = "";
            g6.Reserved = false;
            seats.Add(g6);
            Seat b1 = new Seat();
            b1.SeatCode = "b1";
            b1.OccName = "";
            b1.OccAuth = "";
            b1.Reserved = false;
            seats.Add(b1);
            Seat b2 = new Seat();
            b2.SeatCode = "b2";
            b2.OccName = "";
            b2.OccAuth = "";
            b2.Reserved = false;
            seats.Add(b2);
            Seat b3 = new Seat();
            b3.SeatCode = "b3";
            b3.OccName = "";
            b3.OccAuth = "";
            b3.Reserved = false;
            seats.Add(b3);
            Seat b4 = new Seat();
            b4.SeatCode = "b4";
            b4.OccName = "";
            b4.OccAuth = "";
            b4.Reserved = false;
            seats.Add(b4);
            Seat b5 = new Seat();
            b5.SeatCode = "b5";
            b5.OccName = "";
            b5.OccAuth = "";
            b5.Reserved = false;
            seats.Add(b5);
            Seat b6 = new Seat();
            b6.SeatCode = "b6";
            b6.OccName = "";
            b6.OccAuth = "";
            b6.Reserved = false;
            seats.Add(b6);

            if (!context.Seats.Any())
            {
                context.Seats.AddRange(seats);
                context.SaveChanges();
            }


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
