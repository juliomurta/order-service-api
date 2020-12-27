using OrderService.Api.Common.Validators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderService.Api.Common.Validators
{
    public class CpfValidator : IIdentificationDocument
    {
        public bool IsValid(string documentNumber)
        {            
            if (this.IsBasicStructureInvalid(documentNumber))
            {
                return false;
            }

            const int firstVerifyingDigitPosition = 9;
            const int secondVerifyingDigitPosition = 10;

            var firstDigit  = (int)char.GetNumericValue(documentNumber[firstVerifyingDigitPosition]);
            var secondDigit = (int)char.GetNumericValue(documentNumber[secondVerifyingDigitPosition]);

            return firstDigit  == this.CalculateVerifyingDigit(documentNumber, firstVerifyingDigitPosition) &&
                   secondDigit == this.CalculateVerifyingDigit(documentNumber, secondVerifyingDigitPosition);
        }

        private bool IsBasicStructureInvalid(string documentNumber)
        {
            var allRepeatedNumbers = new string[]
            {
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };

            return string.IsNullOrEmpty(documentNumber) || documentNumber.Length != 11 ||
                   allRepeatedNumbers.Any(x => x == documentNumber);
        }

        private int CalculateVerifyingDigit(string documentNumber, int position)
        {
            int sum = 0;
            for (int i = 0, j = position - 1; i <= position - 1; i++, j--)
            {
                int number = (int)char.GetNumericValue(documentNumber[i]);
                int multiplier = j + 2;
                sum += number * multiplier;
            }

            int result = (sum * 10) % 11;
            if (result == 10)
            {
                result = 0;
            }

            return result;
        }
    }
}
