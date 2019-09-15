using System;

namespace DieteticSNS.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity '{ name }' (Id: { key }) was not found.")
        {
        }
    }
}
