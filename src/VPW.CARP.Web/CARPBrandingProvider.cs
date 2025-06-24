using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using VPW.CARP.Localization;

namespace VPW.CARP.Web;

[Dependency(ReplaceServices = true)]
public class CARPBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<CARPResource> _localizer;

    public CARPBrandingProvider(IStringLocalizer<CARPResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
    //https://abp.io/docs/latest/framework/ui/mvc-razor-pages/branding?_redirected=B8ABF606AA1BDF5C629883DF1061649A
    
    public override string LogoReverseUrl => "images/favicon.svg";
    public override string? LogoUrl => "images/favicon.svg";
}
