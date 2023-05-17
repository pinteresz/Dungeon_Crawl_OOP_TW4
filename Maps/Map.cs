using DungeonCrawl.Tiles;
using SadConsole;
using SadRogue.Primitives;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Ui;
using Console = System.Console;

namespace DungeonCrawl.Maps;

/// <summary>
/// Class <c>Map</c> models a map for the game.
/// </summary>
public class Map
{
    public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
    public ScreenSurface SurfaceObject => _mapSurface;
    public Player UserControlledObject { get; private set; }
    private List<GameObject> _mapObjects;
    private ScreenSurface _mapSurface;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mapWidth"></param>
    /// <param name="mapHeight"></param>
    public Map(int mapWidth, int mapHeight)
    {
        _mapObjects = new List<GameObject>();
        _mapSurface = new ScreenSurface(mapWidth, mapHeight);
        _mapSurface.UseMouse = false;

        UserControlledObject = new Player(_mapSurface.Surface.Area.Center, _mapSurface);
        
        // Create walls and 5 treasure tiles and 5 monster tiles
        
        
        for (int i = 0; i < 3; i++)
        {
            CreateWall();
        }
        CreateBorder();
        CreateBow();
            for (int i = 0; i < 5; i++)
        {
            CreateTreasure();
            CreateMonsterSpider();
            CreateMonsterSnake();
            CreateKey();
        }

    }

    
    
    
    /// <summary>
    /// Try to find a map object at that position.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool TryGetMapObject(Point position, out GameObject gameObject)
    {
        foreach (var otherGameObject in _mapObjects)
        {
            if (otherGameObject.Position == position)
            {
                gameObject = otherGameObject;
                return true;
            }
        }

        gameObject = null;
        return false;
    }

    /// <summary>
    /// Removes an object from the map.
    /// </summary>
    /// <param name="mapObject"></param>
    public void RemoveMapObject(GameObject mapObject)
    {
        if (_mapObjects.Contains(mapObject))
        {
            _mapObjects.Remove(mapObject);
            mapObject.RestoreMap(this);
        }
    }

    /// <summary>
    /// Creates a treasure on the map.
    /// </summary>
    private void CreateTreasure()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject treasure = new Treasure(randomPosition, _mapSurface);
            _mapObjects.Add(treasure);
            break;
        }
    }

    /// <summary>
    /// Creates a monster on the map.
    /// </summary>
    private void CreateMonsterSpider()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject monsterSpider = new MonsterSpider(randomPosition, _mapSurface);
            _mapObjects.Add(monsterSpider);
            break;
        }
    }
    
    private void CreateMonsterSnake()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject monsterSnake = new MonsterSnake(randomPosition, _mapSurface);
            _mapObjects.Add(monsterSnake);
            break;
        }
    }

    private void CreateWall()
    {
        var randomXPosition = Game.Instance.Random.Next(5, _mapSurface.Surface.Width - 5);
        var randomYPosition = Game.Instance.Random.Next(1, _mapSurface.Surface.Height - 1);

        for (int i = 1; i < _mapSurface.Surface.Height-1; i++)
        {
            if(i != randomYPosition)
            {
                Point randomPosition = new Point(randomXPosition, i);

                // Check if any object is already positioned there, repeat the loop if found
                bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition || obj.Position.X == randomPosition.X+1 || obj.Position.X == randomPosition.X-1);
                if (foundObject) randomXPosition = Game.Instance.Random.Next(5, _mapSurface.Surface.Width-5);

                // If the code reaches here, we've got a good position, create the game object.
                GameObject wall = new Wall(randomPosition, _mapSurface);
                _mapObjects.Add(wall);
            }                    

        }

        // Try 1000 times to get an empty map position
       /* for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject wall = new Wall(randomPosition, _mapSurface);
            _mapObjects.Add(wall);
            break;
        }*/
    }

    private void CreateKey()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject key = new Key(randomPosition, _mapSurface);
            _mapObjects.Add(key);
            break;
        }
    }

    private void CreateBorder()
    {
        //left side
        for (int i = 0; i < _mapSurface.Surface.Height; i++)
        {
            
                Point randomPosition = new Point(0, i);
                // If the code reaches here, we've got a good position, create the game object.
                GameObject border = new Border(randomPosition, _mapSurface);
                _mapObjects.Add(border);
        }
        
        //right side
        for (int i = 0; i < _mapSurface.Surface.Height; i++)
        {
            
            Point randomPosition = new Point(_mapSurface.Surface.Width-1, i);
            // If the code reaches here, we've got a good position, create the game object.
            GameObject border = new Border(randomPosition, _mapSurface);
            _mapObjects.Add(border);
        }
        
        //top
        for (int i = 0; i < _mapSurface.Surface.Width; i++)
        {
            
            Point randomPosition = new Point(i, _mapSurface.Surface.Height-1);
            // If the code reaches here, we've got a good position, create the game object.
            GameObject border = new Border(randomPosition, _mapSurface);
            _mapObjects.Add(border);
        }
        
        //bottom
        for (int i = 0; i < _mapSurface.Surface.Width; i++)
        {
            
            Point randomPosition = new Point(i, 0);
            // If the code reaches here, we've got a good position, create the game object.
            GameObject border = new Border(randomPosition, _mapSurface);
            _mapObjects.Add(border);
        }
    }
    private void CreateBow()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject bow = new Bow(randomPosition, _mapSurface);
            _mapObjects.Add(bow);
            break;
        }
    }
}