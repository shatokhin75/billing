namespace Service.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;

    using Swashbuckle.Application;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableSwagger(
                "swagger/docs/{apiVersion}",
                c =>
                {
                    c.Schemes(null);
                    c.RootUrl(RootUrlResolver);
                    c.SingleApiVersion("v1", "Billing API");
                    c.DescribeAllEnumsAsStrings();
                    var xmlPath = AppDomain.CurrentDomain.BaseDirectory + @"bin\app_data\Service.xml";
                    if (File.Exists(xmlPath))
                    {
                        c.IncludeXmlComments(xmlPath);
                    }
                });
        }

        private static string RootUrlResolver(HttpRequestMessage request)
        {
            var scheme = GetHeaderValue(request, "X-Forwarded-Proto") ?? request.RequestUri.Scheme;
            var host = GetHeaderValue(request, "X-Forwarded-Host") ?? request.RequestUri.Host;
            var port = GetHeaderValue(request, "X-Forwarded-Port") ?? request.RequestUri.Port.ToString(CultureInfo.InvariantCulture);
            var httpConfiguration = request.GetConfiguration();
            var virtualPathRoot = httpConfiguration.VirtualPathRoot.TrimEnd('/');
            var httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                var applicationPath = httpContext.Request.ApplicationPath ?? string.Empty;
                if (string.IsNullOrEmpty(virtualPathRoot))
                {
                    virtualPathRoot = applicationPath;
                }
            }

            return string.Format("{0}://{1}:{2}{3}", scheme, host, port, virtualPathRoot);
        }

        private static string GetHeaderValue(HttpRequestMessage request, string headerName)
        {
            IEnumerable<string> values;

            return !request.Headers.TryGetValues(headerName, out values)
                       ? null
                       : values.FirstOrDefault();
        }
    }
}
