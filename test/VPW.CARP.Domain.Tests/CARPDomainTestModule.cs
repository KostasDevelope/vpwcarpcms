using Volo.Abp.Modularity;

namespace VPW.CARP;

[DependsOn(
    typeof(CARPDomainModule),
    typeof(CARPTestBaseModule)
)]
public class CARPDomainTestModule : AbpModule
{

}
