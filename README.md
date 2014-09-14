IIS-CORS-Module
===============

# How to register module
## Register module via code
```csharp
public class Global : System.Web.HttpApplication
{
	public static CrossOriginResourceSharingModule CORSModule = new CrossOriginResourceSharingModule();

	public override void Init()
	{
		base.Init();
		CORSModule.Init(this);
	}
}
```
## Register module via web.config
```xml
<system.webServer>
	<modules runAllManagedModulesForAllRequests="true">
		<add name="CrossOriginResourceSharingModule"
		     type="TeamSpark.IIS.Module.CORS.CrossOriginResourceSharingModule"/>
	</modules>
</system.webServer>
```

# How to configure module
## Configure module via code
```csharp
public class Global : System.Web.HttpApplication
{
	protected void Application_Start(object sender, EventArgs e)
	{
		CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Add("localhost");
		CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Add("localhost:50101");
		CrossOriginResourceSharingModuleConfiguration.Instance.AllowedHosts.Add("localhost:50102");

		CrossOriginResourceSharingModuleConfiguration.Instance.IsDropNotAllowedHosts = true;
	}
}
```
