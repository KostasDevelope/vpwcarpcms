using VPW.CARP.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace VPW.CARP.Web.Pages;

public abstract class CARPPageModel : AbpPageModel
{
    protected CARPPageModel()
    {
        LocalizationResourceType = typeof(CARPResource);
    }
}
