using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveCpfCnpjPunctuation(this string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber))
            {
                return string.Empty;
            }

            return documentNumber.Replace(".", string.Empty)
                                 .Replace("-", string.Empty)
                                 .Replace("/", string.Empty);
        }
    }
}
