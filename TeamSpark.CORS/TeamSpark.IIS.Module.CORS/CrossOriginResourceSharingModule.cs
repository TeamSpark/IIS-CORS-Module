using System;
using System.Net;
using System.Web;

namespace TeamSpark.IIS.Module.CORS
{
	public class CrossOriginResourceSharingModule : IHttpModule
    {
		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += OnBeginRequest;
		}

		private void OnBeginRequest(object sender, EventArgs eventArgs)
		{
			var application = (HttpApplication)sender;
			var request = application.Context.Request;

			var origin = HttpRequestHelper.GetOrigin(request);

			if (string.IsNullOrEmpty(origin))
			{
				return;
			}

			var response = application.Context.Response;
			var uri = new Uri(origin);

			if (CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Contains(uri.Host))
			{
				var methods = request.Headers.Get(HttpRequestHelper.HeaderAccessControlRequestMethod) ?? request.HttpMethod;
				var headers = request.Headers.Get(HttpRequestHelper.HeaderAccessControlRequestHeaders) ?? string.Empty;

				response.AddHeader(HttpRequestHelper.HeaderAccessControlAllowOrigin, origin);
				response.AddHeader(HttpRequestHelper.HeaderAccessControlAllowMethods, methods);
				response.AddHeader(HttpRequestHelper.HeaderAccessControlMaxAge, "1000");
				response.AddHeader(HttpRequestHelper.HeaderAccessControlAllowHeaders, headers);

				if (request.HttpMethod.ToLowerInvariant() == HttpRequestHelper.HttpMethodOptions)
				{
					response.End();
				}
			}
			else
			{
				if (CrossOriginResourceSharingModuleConfiguration.Instance.IsDropNotAllowedHosts)
				{
					response.StatusCode = (int)HttpStatusCode.Forbidden;
					response.StatusDescription = string.Format("Host {0} is not allowed.", uri.Host);
					response.End();
				}
			}
		}
    }
}
