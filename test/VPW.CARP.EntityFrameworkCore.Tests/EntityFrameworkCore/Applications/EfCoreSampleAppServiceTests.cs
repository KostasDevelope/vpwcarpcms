using VPW.CARP.Samples;
using Xunit;

namespace VPW.CARP.EntityFrameworkCore.Applications;

[Collection(CARPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CARPEntityFrameworkCoreTestModule>
{

}
