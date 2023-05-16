using System.Threading;
using System.Threading.Tasks;
using DungeonCrawl.Maps;
using DungeonCrawl.Ui;
using SadConsole;
using SadConsole.UI;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Treasure</c> models a friendly object in the game.
/// </summary>
public class Treasure : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public Treasure(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.LightGreen, Color.Transparent, 4), position, hostingSurface)
    {
    }

    /// <param name="source"></param>
    /// <param name="map"></param>
    /// <returns></returns>
    protected override bool Touched(GameObject source, Map map)
    {
        // Is the player the one that touched us?
        if (source == map.UserControlledObject)
        {
            map.RemoveMapObject(this);
            map.UserControlledObject.PickUpLoot(this);
            
            ((RootScreen)(Game.Instance.Screen)).Console.Clear();
            ((RootScreen)(Game.Instance.Screen)).Console.Print(0,0,$"You picked up a diamond!");
            return true;
        }

        return false;
    }
}