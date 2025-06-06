﻿using ARK.Core.Api.Models.ARKS;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.Core.Api.Services.Foundations.Arks
{
    public interface IArkService
    {
        ValueTask<IQueryable<Ark>> RetrieveAllArksAsync();
    }
}
