using OrderService.Api.Common.Validators.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Common.Validators
{
    public class CnpjValidator : IIdentificationDocument
    {
        public bool IsValid(string documentNumber)
        {
            if (this.IsBasicStructureInvalid(documentNumber))
            {
                return false;
            }

            const int firstVerifyingDigitPosition = 12;
            const int secondVerifyingDigitPosition = 13;

            var firstDigit = (int)char.GetNumericValue(documentNumber[firstVerifyingDigitPosition]);
            var secondDigit = (int)char.GetNumericValue(documentNumber[secondVerifyingDigitPosition]);

            return firstDigit  == this.CalculateVerifyingDigit(documentNumber, firstVerifyingDigitPosition) &&
                   secondDigit == this.CalculateVerifyingDigit(documentNumber, secondVerifyingDigitPosition);
        }

        private int CalculateVerifyingDigit(string documentNumber, int position)
        {            
            var multipliers = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6 };
            int sum = 0;
            for (int i = 0, j = position - 1; i <= position - 1; i++, j--)
            {
                int number = (int)char.GetNumericValue(documentNumber[j]);
                sum += number * multipliers[i];
            }

            int result = (sum * 10) % 11;
            if (result == 10)
            {
                result = 0;
            }

            return result;
        }

        private bool IsBasicStructureInvalid(string documentNumber)
        {
            return string.IsNullOrEmpty(documentNumber) || documentNumber.Length != 14;
        }
    }
}
