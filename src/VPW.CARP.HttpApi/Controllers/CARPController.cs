using VPW.CARP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VPW.CARP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CARPController : AbpControllerBase
{
    protected CARPController()
    {
        LocalizationResource = typeof(CARPResource);
    }
}
