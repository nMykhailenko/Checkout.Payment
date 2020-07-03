using System;
using System.Security.Cryptography;
using System.Text;

namespace Checkout.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Mask input string with 'X'.
        /// </summary>
        /// <param name="source">Input string to mask.</param>
        /// <param name="start">Index from start masking.</param>
        /// <param name="maskLength">Index till make masking.</param>
        /// <returns>Input with masked data.</returns>
        public static string Mask(this string source, int start, int maskLength)
        {
            return source.Mask(start, maskLength, 'X');
        }


        /// <summary>
        /// Mask input string with specific char.
        /// </summary>
        /// <param name="source">Input string to mask.</param>
        /// <param name="start">Index from start masking.</param>
        /// <param name="maskLength">Index till make masking.</param>
        /// <param name="maskCharacter">Char to use for mask.</param>
        /// <returns>Input with masked data.</returns>
        public static string Mask(this string source, int start, int maskLength, char maskCharacter)
        {
            if (start > source.Length - 1)
            {
                throw new ArgumentException("Start position is greater than string length");
            }

            if (maskLength > source.Length)
            {
                throw new ArgumentException("Mask length is greater than string length");
            }

            if (start + maskLength > source.Length)
            {
                throw new ArgumentException("Start position and mask length imply more characters than are present");
            }

            var mask = new string(maskCharacter, maskLength);
            var unMaskStart = source.Substring(0, start);
            var unMaskEnd = source.Substring(start + maskLength, source.Length - maskLength);

            return $"{unMaskStart}{mask}{unMaskEnd}";
        }

        /// <summary>
        /// Encrypt data with SHA512.
        /// </summary>
        /// <param name="source">Input string.</param>
        /// <returns>Hash from input string.</returns>
        public static string EncryptSha512(this string source)
        {
            using var sha512Hash = SHA512.Create();

            var sourceBytes = Encoding.UTF8.GetBytes(source);
            var hashBytes = sha512Hash.ComputeHash(sourceBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return hash;
        }
    }
}
