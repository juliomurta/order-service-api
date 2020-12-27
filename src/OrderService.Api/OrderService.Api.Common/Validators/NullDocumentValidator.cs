using OrderService.Api.Common.Validators.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Common.Validators
{
    public class NullDocumentValidator : IIdentificationDocument
    {
        public bool IsValid(string documentNumber)
        {
            return false;
        }
    }
}
