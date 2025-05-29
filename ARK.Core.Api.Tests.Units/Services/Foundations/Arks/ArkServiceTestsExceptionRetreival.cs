using ARK.Core.Api.Models.ARKS;
using ARK.Core.Api.Models.Ecxeptions;
using FluentAssertions;
using Force.DeepCloner;
using Microsoft.Data.SqlClient;
using Moq;

namespace ARK.Core.Api.Tests.Units.Services.Foundations.Arks
{
    public partial class ArkServiceTests
    {     

        [Fact]
        public async Task ShouldThrowArkDependencyExceptionIfDependencyFailureOccuredAsunc()
        {
            // given
            SqlException sqlException = CreateSqlException();

            var failedArkStorageException =
                new FailedArkStorageExcpeion(
                    message: "Failed Ark storage occured, contact support.", innerException: sqlException);

            var expectedArkDependencyException =
                new ArkDependencyException(
                    message: "Ark dependency error occured, contact support.",
                    innerException: failedArkStorageException);

            this .storageBrokerMock.Setup(broker =>
                broker.SelectAllArksAsync())
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<IQueryable<Ark>> retrieveAllArksTask =
                this.arkService.RetrieveAllArksAsync();

            ArkDependencyException actualArkDependencyException =
                await Assert.ThrowsAsync<ArkDependencyException>(
                    retrieveAllArksTask.AsTask);

            // then
            actualArkDependencyException.Should().BeEquivalentTo(expectedArkDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCriticalAsync(It.Is(SameExceptionAs(
                    expectedArkDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
 