using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Common.Validators.Interface
{
    public interface IIdentificationDocument
    {
        bool IsValid(string documentNumber);
    }
}
