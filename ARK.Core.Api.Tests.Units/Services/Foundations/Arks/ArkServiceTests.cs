using ARK.Core.Api.Models.ARKS;
using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace ARK.Core.Api.Tests.Units.Services.Foundations.Arks
{
    public partial class ArkServiceTests
    {
        [Fact]
        public async Task ShouldRetreiveAllArksAsync()
        {
            // Given
            IQueryable<Ark> randomArks = CreateRandomArks();
            IQueryable<Ark> selectedSrks = randomArks;
            IQueryable<Ark> expectedArks = randomArks.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllArksAsync())
                    .ReturnsAsync(selectedSrks);

            // When
            IQueryable<Ark> actualArks =
                await this.arkService.RetrieveAllArksAsync();

            // Then
            actualArks.Should().BeEquivalentTo(expectedArks);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllArksAsync(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
 