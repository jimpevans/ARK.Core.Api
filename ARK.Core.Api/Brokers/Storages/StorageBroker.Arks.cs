using ARK.Core.Api.Models.ARKS;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Ark> Arks { get; set; }

        public async ValueTask<IQueryable<Ark>> SelectAllArksAsync() =>
            await this.SelectAll<Ark>();
    }
}
