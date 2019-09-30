using FluentAssertions;
using ITG.Brix.Mobile.Bff.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace ITG.Brix.Mobile.Bff.UnitTests.Domain.Model
{
    [TestClass]
    public class FilterKeyTests
    {
        [DataTestMethod]
        [DataRow("filter-key")]
        [DataRow("filterkey")]
        [DataRow("filter-filter-")]
        [DataRow("-filter-key")]
        [DataRow("-filter-filter-")]
        public void CreateFilterKeyShouldSucceed(string filterKey)
        {
            // Arrange
            var value = filterKey;

            // Act
            Action ctor = () => { new FilterKey(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void CreateFilterKeyShouldFailWhenValueIsNull()
        {
            // Arrange
            string value = null;

            // Act
            Action ctor = () => { new FilterKey(value); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*{nameof(value)}*");
        }

        [TestMethod]
        public void CreateFilterKeyShouldFailWhenValueIsStringEmpty()
        {
            // Arrange
            var value = string.Empty;

            // Act
            Action ctor = () => { new FilterKey(value); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*{nameof(value)}*");
        }

        [TestMethod]
        public void CreateFilterKeyShouldFailWhenValueIsWhitespace()
        {
            // Arrange
            string value = "   ";

            // Act
            Action ctor = () => { new FilterKey(value); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*{nameof(value)}*");
        }

        [TestMethod]
        public void CreateFilterKeyShouldProperlyInitializeProperties()
        {
            // Arrange
            var value = "key";

            // Act
            var itemKey = new FilterKey(value);

            // Assert
            itemKey.Value.Should().Be(value);
        }

        [TestMethod]
        public void ListShouldContainAllDefinitions()
        {
            // Arrange
            var type = typeof(FilterKey);
            var expectedCount = type.GetFields(BindingFlags.Public | BindingFlags.Static).Count(f => f.FieldType == type);

            // Act
            var listCount = FilterKey.List().Count();

            // Assert
            listCount.Should().Be(expectedCount);
        }
    }
}
