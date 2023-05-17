namespace DungeonCrawl.Tiles;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadRogue.Primitives;


public class Border : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public Border(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.White, Color.Transparent, '-'), position, hostingSurface)
    {
    }
}
