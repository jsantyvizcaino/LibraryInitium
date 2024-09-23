using Microsoft.AspNetCore.OData.Query;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bookstore.API.Configurations
{
    public class ODataQueryOptionsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var queryAttribute = context.MethodInfo.GetCustomAttributes(true)
                .Union(context.MethodInfo.DeclaringType.GetCustomAttributes(true))
                .OfType<EnableQueryAttribute>().FirstOrDefault();

            if (queryAttribute != null)
            {
                operation.Parameters?.RemoveAt(0);
                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Select))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$select",
                        In = ParameterLocation.Query,
                        Description = "Selects qué propiedades incluir en la respuesta.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Expand))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$expand",
                        In = ParameterLocation.Query,
                        Description = "Expande las entidades relacionadas en línea.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                // Additional OData query options are available for collections of entities only

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Filter))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$filter",
                        In = ParameterLocation.Query,
                        Description = "Filtra los resultados, en función de una condición booleana.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.OrderBy))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$orderby",
                        In = ParameterLocation.Query,
                        Description = "Determina qué valores se utilizan para ordenar una colección de resultados.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Top))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$top",
                        In = ParameterLocation.Query,
                        Description = "El número máximo de resultados.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Skip))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$skip",
                        In = ParameterLocation.Query,
                        Description = "El número de resultados a omitir.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Count))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "$count",
                        In = ParameterLocation.Query,
                        Description = "Devuelve el recuento de resultados.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }
            }
        }
    }
}
