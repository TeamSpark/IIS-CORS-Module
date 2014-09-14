using System;
using TeamSpark.IIS.Module.CORS;

namespace TeamSpark.CORS.Demo.WebService
{
	public class Global : System.Web.HttpApplication
	{
		public static CrossOriginResourceSharingModule CORSModule = new CrossOriginResourceSharingModule();

		public override void Init()
		{
			base.Init();
			CORSModule.Init(this);
		}

		protected void Application_Start(object sender, EventArgs e)
		{
			CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Add("localhost");
			CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Add("localhost:50101");
			CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Add("localhost:50102");

			CrossOriginResourceSharingModuleConfiguration.Instance.IsDropNotAllowedHosts = true;
		}
	}
}