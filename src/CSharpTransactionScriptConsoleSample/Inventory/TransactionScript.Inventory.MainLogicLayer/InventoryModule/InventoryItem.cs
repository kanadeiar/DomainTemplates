using TransactionScript.Inventory.DataAccessLayer.Contracts;

namespace TransactionScript.Inventory.MainLogicLayer.InventoryModule;

public class InventoryItem(int id, string? name, int quantity = 0)
{
    public static InventoryItem Restore(InventoryEntry entry)
    {
        return new InventoryItem(entry.Id, entry.Name, entry.Quantity);
    }
    
    public void Rename(string newName) => name = newName;

    public void Quantity(int newQuantity) => quantity = newQuantity;
    
    public override string ToString() => $"{name} - {quantity} шт.";
    
    public InventoryEntry Backup() =>
        new()
        {
            Id = id,
            Name = name,
            Quantity = quantity
        };
}