using FluentAssertions;
using ITG.Brix.Mobile.Bff.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace ITG.Brix.Mobile.Bff.UnitTests.Domain.Model
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void CreateItemShouldSucceed()
        {
            // Arrange
            ItemKey key = new ItemKey("#key");
            FilterKey filterKey = new FilterKey("key");

            // Act
            Action ctor = () => { new Item(key, filterKey); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void CreateItemKeyShouldFailWhenKeyIsNull()
        {
            // Arrange
            FilterKey filterKey = new FilterKey("key");

            // Act
            Action ctor = () => { new Item(null, filterKey); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*key*");
        }

        [TestMethod]
        public void CreateItemKeyShouldFailWhenFilterKeyIsNull()
        {
            // Arrange
            ItemKey key = new ItemKey("#key");

            // Act
            Action ctor = () => { new Item(key, null); };

            // Assert
            ctor.Should().Throw<ArgumentException>().WithMessage($"*filterKey*");
        }

        [TestMethod]
        public void GetPathFromItemKeyShouldSucceed()
        {
            // Arrange
            var expected = FilterKey.Adr.Value;
            var itemKey = ItemKey.Adr;

            // Act
            var result = Item.GetPath(itemKey);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void GetPathFromStringKeyShouldSucceed()
        {
            // Arrange
            var expected = FilterKey.Adr.Value;
            var stringKey = ItemKey.Adr.Value;

            // Act
            var result = Item.GetPath(stringKey);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void CreateItemShouldProperlyInitializeProperties()
        {
            // Arrange
            ItemKey key = new ItemKey("#key");
            FilterKey filterKey = new FilterKey("key");

            // Act
            var item = new Item(key, filterKey);

            // Assert
            item.Key.Should().Be(key);
            item.FilterKey.Should().Be(filterKey);
        }

        [TestMethod]
        public void ListShouldContainAllDefinitions()
        {
            // Arrange
            var type = typeof(Item);
            var expectedCount = type.GetFields(BindingFlags.Public | BindingFlags.Static).Count(f => f.FieldType == type);

            // Act
            var listCount = Item.List().Count();

            // Assert
            listCount.Should().Be(expectedCount);
        }

    }
}
