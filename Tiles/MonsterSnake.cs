using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

public class MonsterSnake : GameObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="hostingSurface"></param>
        public MonsterSnake(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Red, Color.Transparent, 64), position, hostingSurface)
        {
        }
    
}