using FluentAssertions;
using Kanadeiar.Tests;
using TransactionScript.Inventory.DataAccessLayer.Contracts;
using TransactionScript.Inventory.MainLogicLayer.InventoryModule;

namespace TransactionScript.Inventory.MainLogicLayer.Tests.Unit.InventoryModule;

public class InventoryItemTests
{
    [Theory(DisplayName = "Проверка того, что можно переименовать элемент")]
    [AutoMoqData]
    public void TestRename(InventoryEntry entry)
    {
        var expected = "Новое имя";
        var sut = InventoryItem.Restore(entry);

        sut.Rename(expected);

        var actual = sut.Backup();
        actual.Name.Should().Be(expected);
    }

    [Theory(DisplayName = "Проверка того, что можно изменить количество элементов")]
    [AutoMoqData]
    public void TestQuantity(InventoryEntry entry)
    {
        var expected = 44;
        var sut = InventoryItem.Restore(entry);

        sut.Quantity(expected);

        var actual = sut.Backup();
        actual.Quantity.Should().Be(expected);
    }
}