using System.Collections.Generic;
using System.Linq;
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
    public Dictionary<GameObject, int> inventory;

    public Player(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Green, Color.Transparent, 2), position, hostingSurface)
    {
        inventory = new();
    }

    public void PickUpLoot(GameObject loot)
    {
        if (inventory.ContainsKey(loot))
        {
            inventory[loot]++;
        }
        inventory.Add(loot, 1);
    }
}