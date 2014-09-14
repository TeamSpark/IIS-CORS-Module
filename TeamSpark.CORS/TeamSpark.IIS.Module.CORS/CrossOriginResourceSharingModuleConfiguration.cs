using System.Collections.Generic;

namespace TeamSpark.IIS.Module.CORS
{
	public class CrossOriginResourceSharingModuleConfiguration
	{
		#region Singleton

		private CrossOriginResourceSharingModuleConfiguration()
		{
			_allowedHosts = new List<string>();
			IsDropNotAllowedHosts = false;
		}

		static CrossOriginResourceSharingModuleConfiguration()
		{
			_instance = new CrossOriginResourceSharingModuleConfiguration();
		}

		private static readonly CrossOriginResourceSharingModuleConfiguration _instance;

		public static CrossOriginResourceSharingModuleConfiguration Instance
		{
			get { return _instance; }
		}

		#endregion

		private readonly List<string> _allowedHosts;

		public List<string> AllowedHosts
		{
			get { return _allowedHosts; }
		}

		public bool IsDropNotAllowedHosts
		{ get; set; }
	}
}
