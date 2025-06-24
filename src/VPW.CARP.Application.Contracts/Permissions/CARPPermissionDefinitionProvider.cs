using VPW.CARP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace VPW.CARP.Permissions;

public class CARPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CARPPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(CARPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CARPResource>(name);
    }
}
