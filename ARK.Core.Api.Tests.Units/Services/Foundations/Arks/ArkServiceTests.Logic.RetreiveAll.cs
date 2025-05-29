using ARK.Core.Api.Brokers.Loggings;
using ARK.Core.Api.Brokers.Storages;
using ARK.Core.Api.Models.ARKS;
using ARK.Core.Api.Services.Foundations.Arks;
using Microsoft.Data.SqlClient;
using Moq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Tynamix.ObjectFiller;
using Xeptions;

namespace ARK.Core.Api.Tests.Units.Services.Foundations.Arks
{
    public partial class ArkServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IArkService arkService;

        public ArkServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.arkService = new ArkService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private IQueryable<Ark> CreateRandomArks()
        {
            return CreateArkFiller().Create(count: GetRandomNumber()).AsQueryable();
        }           

        private SqlException CreateSqlException() =>
            (SqlException) RuntimeHelpers.GetUninitializedObject(
                type: typeof(SqlException));

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private Filler<Ark> CreateArkFiller()
        {
            var filler = new Filler<Ark>();

            filler.Setup().OnType<DateTimeOffset>().IgnoreIt();

            return filler;
        }
    }
}
 