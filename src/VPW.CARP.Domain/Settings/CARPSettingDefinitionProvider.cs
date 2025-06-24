using Volo.Abp.Settings;

namespace VPW.CARP.Settings;

public class CARPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CARPSettings.MySetting1));
    }
}
