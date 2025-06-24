using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace VPW.CARP.Pages;

[Collection(CARPTestConsts.CollectionDefinitionName)]
public class Index_Tests : CARPWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
