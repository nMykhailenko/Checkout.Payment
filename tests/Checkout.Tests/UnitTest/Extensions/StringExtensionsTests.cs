using Checkout.Extensions;
using System;
using Xunit;

namespace Checkout.Tests.UnitTest.Extensions
{
    /// <summary>
    /// Contains tests for <see cref="StringExtensions"/>.
    /// </summary>

    public class StringExtensionsTests
    {
        /// <summary>
        ///  Mask will throw argumentException if start index grater then source string length.
        /// </summary>
        [Fact]
        public void Mask_WillThrowArgumentException_If_StartIndexGraterThenSourceStringLength()
        {
            // Arrange
            var startIndex = 10;
            var source = "542578881";
            var expectedError = new ArgumentException("Start position is greater than string length");

            // Act and Assert.
            var ex = Assert.Throws<ArgumentException>(() => source.Mask(startIndex, 2, 'X'));
            Assert.Equal(expectedError.Message, ex.Message);
        }

        /// <summary>
        ///  Mask will throw argumentException if start mask length more then source string length.
        /// </summary>
        [Fact]
        public void Mask_WillThrowArgumentException_If_MaskLengthGraterThenSourceStringLength()
        {
            // Arrange
            var startIndex = 1;
            var maskLength = 11;
            var source = "5425788812";
            var expectedError = new ArgumentException("Mask length is greater than string length");

            // Act and Assert.
            var ex = Assert.Throws<ArgumentException>(() => source.Mask(startIndex, maskLength, 'X'));
            Assert.Equal(expectedError.Message, ex.Message);
        }

        /// <summary>
        ///  Mask will throw argumentException if start mask length and  start index more then source string length.
        /// </summary>
        [Fact]
        public void Mask_WillThrowArgumentException_If_MaskLengthAndStartIndexGraterThenSourceStringLength()
        {
            // Arrange
            var startIndex = 1;
            var maskLength = 10;
            var source = "5425788812";
            var expectedError = new ArgumentException("Start position and mask length imply more characters than are present");

            // Act and Assert.
            var ex = Assert.Throws<ArgumentException>(() => source.Mask(startIndex, maskLength, 'X'));
            Assert.Equal(expectedError.Message, ex.Message);
        }

        /// <summary>
        /// Mask will return masked string with 'X' char.
        /// </summary>
        [Fact]
        public void Mask_WillReturnMaskedString_WithXChar()
        {
            // Arrange
            var startIndex = 2;
            var maskLength = 12;
            var source = "5425788812551188";
            var expectedMaskSource = "54XXXXXXXXXXXX88";

            // Act
            var maskedSource = source.Mask(startIndex, maskLength);

            // Assert
            Assert.Equal(expectedMaskSource, maskedSource);
        }
    }
}
