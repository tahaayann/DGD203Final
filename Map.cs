using System;
using System.Diagnostics;
using System.Numerics;


public class Map
{
    private int[] _widthBoundaries;
    private int[] _heightBoundaries;

    private Vector2 _coordinates;

    private Location[] _locations;
    public Map(int width, int height) 
    {
        _coordinates = new Vector2(0, 0);
        
        int widthBoundary = (width - 1) / 2;

        _widthBoundaries = new int[2];
        _widthBoundaries[0] = -widthBoundary;
        _widthBoundaries[1] = widthBoundary;


        int heightBoundary = (height - 1) / 2;

        _heightBoundaries = new int[2];
        _heightBoundaries[0] = -heightBoundary;
        _heightBoundaries[1] = heightBoundary;

        GenerateLocations();

     

    }


    public Vector2 GetCoordinates()
    {
        return _coordinates;
    }
    public void ChangeCoordinates(Vector2 newCoordinates)
    {
  
        _coordinates = newCoordinates;
    }

    public void MovePlayer(int x, int y)
    {
        int newXCoordinate = (int)_coordinates[0] + x;
        int newYCoordinate = (int)_coordinates[1] + y;
        if (!CanMoveTo(newXCoordinate,newYCoordinate))
        {
            Console.WriteLine("You cant go that way");
            return;
        }
        _coordinates[0] = newXCoordinate;
        _coordinates[1] = newYCoordinate;

        CheckForLocation(_coordinates);


    }

    //public void GoNorth()
    //{
    //    int newYCoordinate = _coordinates[1] + 1;
    //    if (newYCoordinate < _heightBoundaries[1])
    //    {
    //        Console.WriteLine("You cant go that way");
    //        return;
    //    }
    //    _coordinates[1]--;
    //    Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

    //}
    //public void GoSouth()
    //{
    //    int newYCoordinate = _coordinates[1] - 1;
    //    if (newYCoordinate < _heightBoundaries[0])
    //    {
    //        Console.WriteLine("You cant go that way");
    //        return;
    //    }
    //    _coordinates[1]--;
    //    Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");
    //}

    //public void GoEast()
    //{
    //    int newXCoordinate = _coordinates[0] + 1;
    //    if (newXCoordinate > _heightBoundaries[1])
    //    {
    //        Console.WriteLine("You cant go that way");
    //        return;
    //    }
    //    _coordinates[0]++;
    //    Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

    //}

    //public void GoWest()
    //{
    //    int newXCoordinate = _coordinates[0] - 1;
    //    if (newXCoordinate < _heightBoundaries[0])
    //    {
    //        Console.WriteLine("You cant go that way");
    //        return;
    //    }
    //    _coordinates[0]--;
    //    Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

    //}
    private bool CanMoveTo(int x, int y)
    {
        return !(x < _widthBoundaries[0] || x > _widthBoundaries[1] || y < _heightBoundaries[0] || y > _heightBoundaries[1]);
        
    }

    private void GenerateLocations()
    {
        _locations = new Location[3];


        Vector2 calradicLocation = new Vector2(1, 0);
        List<Item> calradicItems = new List<Item>();
        calradicItems.Add(Item.Key);
        Location calradic = new Location("Calradic", calradicLocation, calradicItems);
        _locations[0] = calradic;

        Vector2 vlandiaLocation = new Vector2(-2, 0);
        List<Item> vlandiaItems = new List<Item>();
        vlandiaItems.Add(Item.Rune);
        Location vlandia = new Location("Vlandia", vlandiaLocation, vlandiaItems);
        _locations[1] =  vlandia;

        Vector2 aseraiLocation = new Vector2(1, -2);
        List<Item> aseraiItems = new List<Item>();
        aseraiItems.Add(Item.Paper);
        Location aserai = new Location("Aseria", aseraiLocation, aseraiItems);
        _locations[2] = aserai;


    }

    public void CheckForLocation(Vector2 coordinates)
    {
        Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

        if (IsOnLocation(_coordinates, out Location location))
        {
            Console.WriteLine($"You are in {location.Name} ");
            if (HasItem(location))
            {
                Console.WriteLine($"There is a {location.ItemsOnLocation[0]} here");
            }

        }
      

    }

    public bool IsOnLocation(Vector2 coords, out Location foundLocation)
    {

        for (int i = 0; i < _locations.Length; i++)
        {
            if (_locations[i].Coordiantes == coords)
            {
                foundLocation = _locations[i];  
                return true;
            }
        }
        foundLocation = null;
        return false;

    }

    private bool  HasItem(Location location)
    {
        return location.ItemsOnLocation.Count != 0;
     

    }

    public void TakeItem(Location location)
    {
        

    }

    public void TakeItem(Player player, Vector2 coordinates)
    {
        if (IsOnLocation(coordinates, out Location location))
        {
            if (HasItem(location))
            {
                Item itemOnLocation = location.ItemsOnLocation[0];

                player.TakeItem(itemOnLocation);
                location.RemoveItem(itemOnLocation);

                Console.WriteLine($"You took the {itemOnLocation}");

                return;
            }
        }

        Console.WriteLine("There is nothing to take here!");
    }



}
