using TransactionScript.Inventory.DataAccessLayer.Data;
using TransactionScript.Inventory.MainLogicLayer.InventoryModule;

namespace TransactionScript.Inventory.PresentationLayer.Scripts;

public class InventoryScript(InventoryStorage storage)
{
    public void InitDemo()
    {
        AddItem("Колбаса");
        AddItem("Сыр");
        AddItem("Хлеб");
    }

    public IEnumerable<string> AllItems()
    {
        return storage.All().Select(InventoryItem.Restore).Select(item => $"{item}");
    }

    public int AddItem(string name)
    {
        try
        {
            storage.BeginTransaction();

            var id = storage.NextIdentity();
            var item = new InventoryItem(id, name);
            var entry = item.Backup();
            
            storage.Save(entry);
            storage.Commit();
            return id;
        }
        catch (Exception e)
        {
            storage.Rollback();
            Console.WriteLine(e);
            throw;
        }
    }

    public void ChangeName(int id, string newName)
    {
        try
        {
            storage.BeginTransaction();
            var loaded = storage.Load(id);
            var item = InventoryItem.Restore(loaded);

            item.Rename(newName);

            var entry = item.Backup();
            storage.Save(entry);
            storage.Commit();
        }
        catch (Exception e)
        {
            storage.Rollback();
            Console.WriteLine(e);
            throw;
        }
    }

    public void ChangeQuantity(int id, int newQuantity)
    {
        try
        {
            storage.BeginTransaction();
            var loaded = storage.Load(id);
            var item = InventoryItem.Restore(loaded);

            item.Quantity(newQuantity);

            var entry = item.Backup();
            storage.Save(entry);
            storage.Commit();
        }
        catch (Exception e)
        {
            storage.Rollback();
            Console.WriteLine(e);
            throw;
        }
    }
}