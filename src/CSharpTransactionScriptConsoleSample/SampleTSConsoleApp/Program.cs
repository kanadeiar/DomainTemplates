using Kanadeiar.Common;
using TransactionScript.Inventory.DataAccessLayer.Data;
using TransactionScript.Inventory.PresentationLayer.Scripts;

ConsoleHelper.PrintHeader("Образец вспомогательного поддомена на языке C#", "Образцы предметно-ориентированно проектированых приложений");
ConsoleHelper.PrintLine("Технологии: транзакционный сценарий и трехслойная архитектура");

var storage = new InventoryStorage();
var script = new InventoryScript(storage);
script.InitDemo();

Console.WriteLine("Все:");
foreach (var text in script.AllItems())
{
    Console.WriteLine(text);
}

var id = script.AddItem("newItem");
script.ChangeQuantity(id, 33);
script.ChangeName(id, "Changed name");

Console.WriteLine("Все после изменения:");
foreach (var text in script.AllItems())
{
    Console.WriteLine(text);
}

ConsoleHelper.PrintFooter();
