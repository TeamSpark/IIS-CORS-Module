using System.Web;

namespace TeamSpark.IIS.Module.CORS
{
	internal class HttpRequestHelper
	{
		public const string HeaderOrigin = "Origin";
		public const string HeaderHost = "Host";

		public const string HeaderAccessControlRequestMethod = "Access-Control-Request-Method";
		public const string HeaderAccessControlRequestHeaders = "Access-Control-Request-Headers";
		public const string HeaderAccessControlAllowOrigin = "Access-Control-Allow-Origin";
		public const string HeaderAccessControlAllowMethods = "Access-Control-Allow-Methods";
		public const string HeaderAccessControlMaxAge = "Access-Control-Max-Age";
		public const string HeaderAccessControlAllowHeaders = "Access-Control-Allow-Headers";

		public const string HttpMethodOptions = "options";

		internal static string GetOrigin(HttpRequest request)
		{
			var origin = request.Headers.Get(HeaderOrigin);

			if (string.IsNullOrEmpty(origin))
			{
				origin = string.Format("http{0}://{1}",
					request.IsSecureConnection ? "s" : string.Empty,
					request.Headers.Get(HeaderHost));
			}

			return origin;
		}
	}
}
