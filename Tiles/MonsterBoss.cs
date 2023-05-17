using System.Text;
using DungeonCrawl.Maps;
using DungeonCrawl.Ui;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

public class MonsterBoss : GameObject
{
        
    public int Health { get; set; }
    public int Damage { get; set; }
        
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public MonsterBoss(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Red, Color.Transparent, 1), position, hostingSurface)
    {
        Health = 50;
        Damage = 4;
    }
        
    protected override bool Touched(GameObject source, Map map)
    {
        // Is the player the one that touched us?
        if (source == map.UserControlledObject)
        {
            Health -= map.UserControlledObject.Damage;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= Health; i++)
            {
                sb.Append((char)254);
            }
            ((RootScreen)(Game.Instance.Screen)).Console.Clear();
            ((RootScreen)(Game.Instance.Screen)).Console.Print(0,0,$"The Boss {sb} {Health}/50");
                

            if (Health <= 0)
            {
                map.RemoveMapObject(this);
                ((RootScreen)(Game.Instance.Screen)).GameOver.Clear();
                ((RootScreen)(Game.Instance.Screen)).GameOver.Print(40,12,$"You defeated The Boss!");
                return true;
            }
            else
            {
                map.UserControlledObject.GetDamage(Damage);
            }
        }
        return false;
    }

}