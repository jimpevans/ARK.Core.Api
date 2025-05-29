using Xeptions;

namespace ARK.Core.Api.Models.Ecxeptions
{
    public class ArkDependencyException : Xeption
    {
        public ArkDependencyException(string message, Xeption innerException) : base(message, innerException)
        {            
        }
    }
}
