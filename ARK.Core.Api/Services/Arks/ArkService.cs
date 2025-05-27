using ARK.Core.Api.Models.ARKS;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.Core.Api.Services.Arks
{
    public class ArkService : IArkService
    {
        public ValueTask<IQueryable<Ark>> RetrieveAllArksAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
