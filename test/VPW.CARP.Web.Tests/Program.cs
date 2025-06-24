using Microsoft.AspNetCore.Builder;
using VPW.CARP;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("VPW.CARP.Web.csproj"); 
await builder.RunAbpModuleAsync<CARPWebTestModule>(applicationName: "VPW.CARP.Web");

public partial class Program
{
}
