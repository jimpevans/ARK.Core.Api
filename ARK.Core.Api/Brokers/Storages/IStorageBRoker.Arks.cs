using ARK.Core.Api.Models.ARKS;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.Core.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<IQueryable<Ark>> SelectAllArksAsync();
    }
}
