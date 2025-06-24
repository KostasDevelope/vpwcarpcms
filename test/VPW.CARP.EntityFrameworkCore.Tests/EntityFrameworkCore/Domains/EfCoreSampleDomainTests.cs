using VPW.CARP.Samples;
using Xunit;

namespace VPW.CARP.EntityFrameworkCore.Domains;

[Collection(CARPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CARPEntityFrameworkCoreTestModule>
{

}
