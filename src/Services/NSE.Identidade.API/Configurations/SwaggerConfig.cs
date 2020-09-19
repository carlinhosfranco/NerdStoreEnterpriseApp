using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Identidade.API.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                //x.SchemaFilter<EnumSchemaFilter>();
                // x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     In = ParameterLocation.Header,
                //     Scheme = "Bearer",
                //     BearerFormat = "JWT",
                //     Description = "Please enter into field the word 'Bearer' following by space and JWT Token",
                //     Name = "Authorization",
                //     Type = SecuritySchemeType.ApiKey
                // });

                //x.OperationFilter<AuthResponsesOperationFilter>();

                //x.EnableAnnotations();

                x.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "NerdStore API",
                    Version = "",
                    Description = ""
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                
                // x.IncludeXmlComments(xmlPath);
                // x.AddFluentValidationRules();
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>{
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json",name: "v1");
            });

            return app;
        }
        
    }
}