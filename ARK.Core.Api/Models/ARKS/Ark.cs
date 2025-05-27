using System;

namespace ARK.Core.Api.Models.ARKS
{
    public class Ark
    {
        public Guid Id { get; set; }
        public  DateTimeOffset Date { get; set; }
        public string Act { get; set; }
    }
}
