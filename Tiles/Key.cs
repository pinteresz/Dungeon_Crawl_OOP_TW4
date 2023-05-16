using DungeonCrawl.Maps;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Ui;
using SadRogue.Primitives;
using Console = System.Console;


namespace DungeonCrawl.Tiles
{
    public class Key : GameObject
    {
        public Key(Point position, IScreenSurface hostingSurface)
       : base(new ColoredGlyph(Color.Orange, Color.Transparent, 213), position, hostingSurface)
        {
        }

        protected override bool Touched(GameObject source, Map map)
        {
            // Is the player the one that touched us?
            if (source == map.UserControlledObject)
            {
                map.RemoveMapObject(this);
                map.UserControlledObject.PickUpLoot(this);
                
            
                ((RootScreen)(Game.Instance.Screen)).Console.Clear();
                ((RootScreen)(Game.Instance.Screen)).Console.Print(0,0,$"You picked up a key!");
                return true;
            }

            return false;
        }
    }
}
