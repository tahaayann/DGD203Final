using System;
using System.Numerics;

public class Location
    {
    public string Name {  get; private set; }
    public Vector2 Coordiantes {  get; private set; }


    public List<Item> ItemsOnLocation { get; private set; }


    public Location(string LocationName, Vector2 coordinates, List<Item> itemsOnLocation) 
    {
        Name = LocationName;
        Coordiantes = coordinates;
        ItemsOnLocation = itemsOnLocation;
    
    }
   
    public Location(string LocationName, Vector2 coordinates) 
    {
        Name = LocationName;
        Coordiantes = coordinates;
        ItemsOnLocation = new List<Item>();


    }

    public void RemoveItem(Item item)
    {
        ItemsOnLocation.RemoveAt(0);    

    }

    }

