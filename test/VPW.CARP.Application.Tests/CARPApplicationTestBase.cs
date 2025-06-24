using Volo.Abp.Modularity;

namespace VPW.CARP;

public abstract class CARPApplicationTestBase<TStartupModule> : CARPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
