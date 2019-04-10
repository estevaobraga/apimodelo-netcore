using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apimodelo.netcore.presentation.webapi.Swagger
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "access token",
                    Required = true,
                    Type = "string"
                });
            }
        }
    }

    /// <summary>
    /// SwaggerResponseContentTypeAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerProducesAttribute : Attribute
    {
        public SwaggerProducesAttribute(params string[] contentTypes)
        {
            this.ContentTypes = contentTypes;
        }

        public IEnumerable<string> ContentTypes { get; }
    }

    public class ProducesOperatioFilter : IOperationFilter
    {

        public void Apply(Operation operation, OperationFilterContext context)
        {


            var controllerActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if (controllerActionDescriptor != null)
            {
                var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Where(e => e.GetType() == typeof(SwaggerProducesAttribute)).Select(x => (SwaggerProducesAttribute)x).FirstOrDefault();

                if (actionAttributes == null)
                {
                    return;
                }

                operation.Produces.Clear();
                operation.Produces = actionAttributes.ContentTypes.ToList();
            }



        }
    }
}
