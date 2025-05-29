using System;
using Xeptions;

namespace ARK.Core.Api.Models.Ecxeptions
{
    public class FailedArkStorageExcpeion : Xeption
    {
        public FailedArkStorageExcpeion(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
