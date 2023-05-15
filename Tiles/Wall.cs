using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadRogue.Primitives;


namespace DungeonCrawl.Tiles
{
    public class Wall : GameObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="hostingSurface"></param>
        public Wall(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.LightBlue, Color.LightBlue, 'W'), position, hostingSurface)
        {
        }
    }
}
