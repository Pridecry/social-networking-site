using System;

namespace DieteticSNS.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity '{ name }' (Id: { key }) was not found.")
        {
        }
    }
}
