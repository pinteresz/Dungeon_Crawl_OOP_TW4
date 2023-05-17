using DungeonCrawl.Maps;
using DungeonCrawl.Ui;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

public class MonsterSnake : GameObject
    {
        
        public int Health { get; set; }
        public int Damage { get; set; }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="hostingSurface"></param>
        public MonsterSnake(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Red, Color.Transparent, 64), position, hostingSurface)
        {
            Health = 12;
            Damage = 4;
        }
        
        protected override bool Touched(GameObject source, Map map)
        {
            // Is the player the one that touched us?
            if (source == map.UserControlledObject)
            {
                ((RootScreen)(Game.Instance.Screen)).Console.Print(50,Game.Instance.ScreenCellsY-2,$"The snake took {map.UserControlledObject.Damage} damage!");
                Health -= map.UserControlledObject.Damage;
                

                if (Health <= 0)
                {
                    map.RemoveMapObject(this);
                    ((RootScreen)(Game.Instance.Screen)).Console.Clear();
                    ((RootScreen)(Game.Instance.Screen)).Console.Print(50,Game.Instance.ScreenCellsY-2,$"You defeated the snake!");
                    return true;
                }
                else
                {
                    //map.UserControlledObject.Health -= Damage;
                    map.UserControlledObject.GetDamage(Damage);
                }
            
            }

            return false;
        }
    
}