using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIVersioning.SwaggerOptions
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach(var desc in _provider.ApiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Title = "API Versioning",
                    Version = desc.ApiVersion.ToString(),
                    Description = "This version is " + (desc.IsDeprecated ? "deprecated" : "supported")
                };

                options.SwaggerDoc(desc.GroupName, info);
            }
        }
    }
}
