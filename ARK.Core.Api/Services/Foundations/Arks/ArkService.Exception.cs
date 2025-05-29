using ARK.Core.Api.Brokers.Loggings;
using ARK.Core.Api.Brokers.Storages;
using ARK.Core.Api.Models.ARKS;
using ARK.Core.Api.Models.Ecxeptions;
using ARK.Core.Api.Services.Foundations.Arks;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace ARK.Core.Api.Services.Foundations.Arks
{
    public partial class ArkService : IArkService
    {
        private delegate ValueTask<IQueryable<Ark>> ReturningArksFunction();

        private async ValueTask<IQueryable<Ark>> TryCatch(
            ReturningArksFunction returningArksFunction)
        {
            try
            {
                return await returningArksFunction();
            }
            catch (SqlException sqlException)
            {
               var failedArkStorageException =
                    new FailedArkStorageExcpeion(
                        "Failed Ark storage occured, contact support.", 
                        sqlException);

               throw await ThrowAndLogDependencyException(
                    failedArkStorageException);
            }

            return null;
        }

        private async ValueTask<ArkDependencyException> ThrowAndLogDependencyException(Xeption exception)
        {
            var arkDependencyException =
                new ArkDependencyException(
                    "Ark dependency error occured, contact support.",
                    exception);

            await this.loggingBroker.LogCriticalAsync(arkDependencyException);
            return arkDependencyException;
        }
    }
}
    