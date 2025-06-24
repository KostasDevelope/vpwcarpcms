using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.BlobStoring.Google;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit;
using Volo.CmsKit.Localization;
using VPW.CARP.Localization;

namespace VPW.CARP;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(BlobStoringDatabaseDomainSharedModule),
    typeof(AbpBlobStoringGoogleModule)
    )]
[DependsOn(typeof(CmsKitDomainSharedModule))]
public class CARPDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CARPGlobalFeatureConfigurator.Configure();
        CARPModuleExtensionConfigurator.Configure();

    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CARPDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CARPResource>("uk-UA")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/CARP");

            options.Resources
                .Get<CmsKitResource>()
                .AddVirtualJson("/Localization/CMSCARP");

         
            options.DefaultResourceType = typeof(CARPResource);
            options.Languages.Add(new LanguageInfo("uk-UA", "uk-UA", "Український"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Рус"));
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("CARP", typeof(CARPResource));
        });

        //github.com/EngincanV/Volo.Abp.BlobStoring.Gcp?tab=readme-ov-file
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                {
                    var scopes = configuration["StoringGoogleProvider:Scopes"]?.Split(";")?.ToList() ?? new List<string>();
                    container.UseGoogle(google =>
                    {
                        google.ClientEmail = configuration["StoringGoogleProvider:ClientEmail"];
                        google.ProjectId = configuration["StoringGoogleProvider:ProjectId"];
                        google.PrivateKey = configuration["StoringGoogleProvider:PrivateKey"];
                        google.Scopes = scopes;
                        google.ContainerName = configuration["StoringGoogleProvider:ContainerName"];
                        google.CreateContainerIfNotExists = bool.TryParse(configuration["StoringGoogleProvider:CreateContainerIfNotExists"], out bool createContainerIfNotExists) ? createContainerIfNotExists : false;
                        google.UseApplicationDefaultCredentials = bool.TryParse(configuration["StoringGoogleProvider:UseApplicationDefaultCredentials"], out bool UseApplicationDefaultCredentials) ? UseApplicationDefaultCredentials : false; // If you want to use application default credentials
                    });
                }
            });
        });
    }
}


//Code   https://github.com/abpframework/abp/blob/rel-9.2/docs/en/framework/infrastructure/blob-storing/google.md