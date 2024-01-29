using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string Name { get;private set; }
    public Inventory Items { get; private set; }

    public Inventory Inventory { get; private set; }
    public Player(string name)
    {
        Name = name;
        Items = new Inventory();
       
    }

    public void TakeItem(Item item)
    {
        Items.AddItem(item);

    }

    

}
