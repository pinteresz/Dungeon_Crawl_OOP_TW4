using DungeonCrawl.Maps;
using DungeonCrawl.Ui;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Monster</c> models a hostile object in the game.
/// </summary>
public class MonsterSpider : GameObject
{
    
    public int Health { get; set; }
    public int Damage { get; set; }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public MonsterSpider(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Red, Color.Transparent, 15), position, hostingSurface)
    {
        Health = 7;
        Damage = 2;
    }
    
    protected override bool Touched(GameObject source, Map map)
    {
        // Is the player the one that touched us?
        if (source == map.UserControlledObject)
        {
            ((RootScreen)(Game.Instance.Screen)).Console.Print(20,Game.Instance.ScreenCellsY-5,$"The spider took {map.UserControlledObject.Damage} damage!");
            Health -= map.UserControlledObject.Damage;
            if (Health <= 0)
            {
                map.RemoveMapObject(this);
                ((RootScreen)(Game.Instance.Screen)).Console.Clear();
                ((RootScreen)(Game.Instance.Screen)).Console.Print(20,Game.Instance.ScreenCellsY-5,$"You defeated the spider!");
                return true;
            }
            map.UserControlledObject.GetDamage(Damage);
        }
        return false;
    }
    
}