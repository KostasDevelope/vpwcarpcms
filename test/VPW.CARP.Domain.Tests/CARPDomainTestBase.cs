using Volo.Abp.Modularity;

namespace VPW.CARP;

/* Inherit from this class for your domain layer tests. */
public abstract class CARPDomainTestBase<TStartupModule> : CARPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
