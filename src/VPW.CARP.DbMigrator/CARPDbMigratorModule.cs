using VPW.CARP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace VPW.CARP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CARPEntityFrameworkCoreModule),
    typeof(CARPApplicationContractsModule)
)]
public class CARPDbMigratorModule : AbpModule
{
}
