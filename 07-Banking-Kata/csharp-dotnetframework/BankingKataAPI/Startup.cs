using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Katas
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<AccountsService, AccountsService>();
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var context = app.ApplicationServices.GetService<ApiContext>();
            AddTestData(context);
            app.UseMvc();
        }

        private static void AddTestData(ApiContext context)
        {
            var testAccount1 = new Account(new Money(123, "en-US"));
            context.Accounts.Add(testAccount1);
            context.SaveChanges();
        }
    }
}