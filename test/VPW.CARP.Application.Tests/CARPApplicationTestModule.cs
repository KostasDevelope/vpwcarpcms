using Volo.Abp.Modularity;

namespace VPW.CARP;

[DependsOn(
    typeof(CARPApplicationModule),
    typeof(CARPDomainTestModule)
)]
public class CARPApplicationTestModule : AbpModule
{

}
