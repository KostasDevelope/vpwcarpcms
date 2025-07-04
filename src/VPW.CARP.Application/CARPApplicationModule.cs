using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.CmsKit;
using Volo.Abp.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Validation.Localization;

namespace VPW.CARP;

[DependsOn(
    typeof(CARPDomainModule),
    typeof(CARPApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
[DependsOn(typeof(CmsKitApplicationModule))]
    public class CARPApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CARPApplicationModule>();
        });
       
    }
}
//https://github.com/abpframework/abp/blob/rel-9.3/modules/account/src/Volo.Abp.Account.Application.Contracts/Volo/Abp/Account/Localization/AccountResource.cs
