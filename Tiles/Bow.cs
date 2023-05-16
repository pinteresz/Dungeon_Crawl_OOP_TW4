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
    public class Bow : GameObject
    {
        public Bow(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.SandyBrown, Color.Transparent, 125), position, hostingSurface)
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
                ((RootScreen)(Game.Instance.Screen)).Console.Print(50,Game.Instance.ScreenCellsY-2,$"You picked up a bow!");
                return true;
            }

            return false;
        }
    }
}