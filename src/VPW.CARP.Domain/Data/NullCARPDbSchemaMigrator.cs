using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VPW.CARP.Data;

/* This is used if database provider does't define
 * ICARPDbSchemaMigrator implementation.
 */
public class NullCARPDbSchemaMigrator : ICARPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
