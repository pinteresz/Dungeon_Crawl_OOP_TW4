using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Player</c> models a user controlled object in the game.
/// </summary>
public class Player : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public List<GameObject> inventoryTreasure;
    public List<GameObject> inventoryKey;
    public List<GameObject> inventoryBow;

    public Player(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Green, Color.Transparent, 2), position, hostingSurface)
    {
        inventoryTreasure = new();
        inventoryKey = new();
        inventoryBow = new();
    }

    public void PickUpLoot(GameObject loot)
    {
        
        if (loot is Key)
        {
            inventoryKey.Add(loot);
        }
        
        if (loot is Treasure)
        {
            inventoryTreasure.Add(loot);
        }
        
        if (loot is Bow)
        {
            inventoryBow.Add(loot);
        }
    }
}