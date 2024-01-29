using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inventory
{
    public List<Item> Items { get; private set; }
    public Inventory()
    {
        Items = new List<Item>();

    }

    public void AddItem(Item item)
    {
        if (Items.Contains(item))
        {
            Console.WriteLine($"Your inventory already cotains {item}.");
            return;
        }

        Console.WriteLine($"You added {item} to your inventory.");

        Items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        if (!Items.Contains(item))
        {
            Console.WriteLine($"{item} is not in your inventory.");
            return;
        }
        Console.WriteLine($"{item} is.");

    }

}

public enum Item
{
    Key,
    Paper,
    Rune,

}
