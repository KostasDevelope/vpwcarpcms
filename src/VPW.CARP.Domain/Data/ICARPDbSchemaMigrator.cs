using System.Threading.Tasks;

namespace VPW.CARP.Data;

public interface ICARPDbSchemaMigrator
{
    Task MigrateAsync();
}
