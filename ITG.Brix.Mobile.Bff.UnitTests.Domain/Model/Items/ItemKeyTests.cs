using FluentAssertions;
using ITG.Brix.Mobile.Bff.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace ITG.Brix.Mobile.Bff.UnitTests.Domain.Model
{
    [TestClass]
    public class ItemKeyTests
    {
        [DataTestMethod]
        [DataRow("#business_key")]
        [DataRow("#businesskey")]
        [DataRow("#businesskey1")]
        [DataRow("#businesskey10")]
        [DataRow("#business_key_")]
        [DataRow("#_business_key")]
        [DataRow("#_business_key_")]
        public void CreateItemKeyShouldSucceed(string businessKey)
        {
            // Arrange
            var value = businessKey;

            // Act
            Action ctor = () => { new ItemKey(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void CreateItemKeyShouldFailWhenValueIsNull()
        {
            // Arrange
            string value = null;

            // Act
            Action ctor = () => { new ItemKey(value); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*{nameof(value)}*");
        }

        [TestMethod]
        public void CreateItemKeyShouldFailWhenValueIsStringEmpty()
        {
            // Arrange
            var value = string.Empty;

            // Act
            Action ctor = () => { new ItemKey(value); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*{nameof(value)}*");
        }

        [TestMethod]
        public void CreateItemKeyShouldFailWhenValueIsWhitespace()
        {
            // Arrange
            string value = "   ";

            // Act
            Action ctor = () => { new ItemKey(value); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*{nameof(value)}*");
        }

        [TestMethod]
        public void CreateItemKeyShouldProperlyInitializeProperties()
        {
            // Arrange
            var value = "#key";

            // Act
            var itemKey = new ItemKey(value);

            // Assert
            itemKey.Value.Should().Be(value);
        }

        [TestMethod]
        public void ListShouldContainAllDefinitions()
        {
            // Arrange
            var type = typeof(ItemKey);
            var expectedCount = type.GetFields(BindingFlags.Public | BindingFlags.Static).Count(f => f.FieldType == type);

            // Act
            var listCount = ItemKey.List().Count();

            // Assert
            listCount.Should().Be(expectedCount);
        }

    }
}
