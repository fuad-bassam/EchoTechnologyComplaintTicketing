using EchoTechnologyComplaintTicketing.Data;
using EchoTechnologyComplaintTicketingApp.Common.refit;
using EchoTechnologyComplaintTicketingApp.Models.User;
using EchoTechnologyComplaintTicketingApp.Services.Repository.Generic;
using EchoTechnologyComplaintTicketingApp.Services.Repository.Tickets;
using EchoTechnologyComplaintTicketingApp.Services.Repository.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp
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

            services.AddControllers();
            services.AddDbContext<EchoTechDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<EchoTechDbContext>()
                .AddDefaultTokenProviders();

            // JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            //     // Refit
            //     var demandApiBaseUrl = Configuration.GetValue<string>("DemandApiBaseUrl");
            //     services.AddRefitClient<IDemandApi>()
            //.ConfigureHttpClient(c => c.BaseAddress = new Uri(demandApiBaseUrl));

            services.AddCors(options =>
            {
                options.AddPolicy("allCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });

            //Service
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IComplaintServices, ComplaintServices>();
            services.AddScoped<IDemandServices, DemandServices>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminPrivilege", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("IsAdminPrivilege", "true");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EchoTechnologyComplaintTicketingApp", Version = "v1" });
            });
            services.AddMvc()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EchoTechnologyComplaintTicketingApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("allCors");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
