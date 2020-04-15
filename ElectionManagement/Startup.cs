using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ElectionManagement
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
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
     options.TokenValidationParameters = new TokenValidationParameters
     {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true,
       ValidIssuer = Configuration["Jwt:Issuer"],
       ValidAudience = Configuration["Jwt:Issuer"],
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
     };
   });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddTransient<IAdminBusiness, AdminBusiness>();
      services.AddTransient<IAdminRepository, AdminRepository>();
      services.AddTransient<IPartyBusiness, PartyBusiness>();
      services.AddTransient<IPartyRepository, PartyRepository>();
      services.AddTransient<IConstituencyRepository,ConstituencyRepo>();
      services.AddTransient<IConstituencyBusiness, ConstituencyBusiness>();
      services.AddTransient<ICandidateRepository, CandidateRepository>();
      services.AddTransient<ICandidateBusiness, CandidateBusiness>();
      services.AddTransient<IUserVotingRepository, UserVotingRepository>();
      services.AddTransient<IUserVotingBusiness, UserVotingBusiness>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new ApiKeyScheme
        {
          Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
          In = "header",
          Name = "Authorization",
          Type = "apiKey"
        });

        c.DocumentFilter<SecurityRequirementDocumentFilter>();
      });
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200")
            );
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
      app.UseCors("CorsPolicy");
      app.UseSwagger();
      app.UseAuthentication();
      app.UseHttpsRedirection();
      app.UseMvc();
      app.UseSwaggerUI(
       c =>
       {
         c.SwaggerEndpoint("/swagger/v1/swagger.json", " My API v1");
       });
    }
  }
    public class SecurityRequirementDocumentFilter : IDocumentFilter
    {
      public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
      {
        swaggerDoc.Security = new List<IDictionary<string, IEnumerable<string>>>()
      {
        new Dictionary<string,IEnumerable<string>>()
        {
          {"Bearer",new string[]{ } },
          {"Basic",new string[]{ } },
        }
      };
      }
    }
  }

