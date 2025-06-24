using VPW.CARP.Localization;
using Volo.Abp.Application.Services;

namespace VPW.CARP;

/* Inherit your application services from this class.
 */
public abstract class CARPAppService : ApplicationService
{
    protected CARPAppService()
    {
        LocalizationResource = typeof(CARPResource);
    }
}
