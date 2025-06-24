using Xunit;

namespace VPW.CARP.EntityFrameworkCore;

[CollectionDefinition(CARPTestConsts.CollectionDefinitionName)]
public class CARPEntityFrameworkCoreCollection : ICollectionFixture<CARPEntityFrameworkCoreFixture>
{

}
