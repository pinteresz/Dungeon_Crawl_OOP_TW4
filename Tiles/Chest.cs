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
    public class Chest : GameObject
    {
        public Chest(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.DarkKhaki, Color.Transparent, 22), position, hostingSurface)
        {
        }

        protected override bool Touched(GameObject source, Map map)
        {
            // Is the player the one that touched us?
            if (source == map.UserControlledObject)
            {
                if (map.UserControlledObject.inventoryKey.Count > 0)
                {
                    map.UserControlledObject.Health += 5;
                    ((RootScreen)(Game.Instance.Screen)).Console.Clear();
                    ((RootScreen)(Game.Instance.Screen)).Console.Print(20,Game.Instance.ScreenCellsY-5,$"Your health increased by 5!");    
                }


                map.RemoveMapObject(this);
                map.UserControlledObject.PickUpLoot(this);
                map.UserControlledObject.Damage += 5;
                
                
                return true;
            }

            return false;
        }
    }
}