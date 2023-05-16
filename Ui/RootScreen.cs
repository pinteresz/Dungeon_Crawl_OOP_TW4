using System.Linq;
using System.Text;
using DungeonCrawl.Maps;
using DungeonCrawl.Tiles;
using SadConsole;
using SadConsole.Input;
using SadRogue.Primitives;

namespace DungeonCrawl.Ui;

/// <summary>
/// Class <c>RootScreen</c> provides parent/child, components, and position.
/// </summary>
public class RootScreen : ScreenObject
{
    private Map _map;
    public Console Console;
    public Console InventoryTreasure;
    public Console InventoryKey;
    public Console InventoryBow;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public RootScreen()
    {
        _map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 5);
        Children.Add(_map.SurfaceObject);
    }

    /// <summary>
    /// Processes keyboard inputs.
    /// </summary>
    /// <param name="keyboard"></param>
    /// <returns></returns>
    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(Keys.Up))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Up, _map);
            handled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.Down))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Down, _map);
            handled = true;
        }

        if (keyboard.IsKeyPressed(Keys.Left))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Left, _map);
            handled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.Right))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Right, _map);
            handled = true;
        }

        if (keyboard.IsKeyPressed(Keys.B) || keyboard.IsKeyPressed(Keys.I))
        { 
            if (_map.UserControlledObject.inventoryTreasure.Any())
            {
                ((RootScreen)(Game.Instance.Screen)).InventoryTreasure.Print(0, Game.Instance.ScreenCellsY - 3, $"Treasures: {_map.UserControlledObject.inventoryTreasure.Count()}");
            }

            if (_map.UserControlledObject.inventoryKey.Any())
            {
                ((RootScreen)(Game.Instance.Screen)).InventoryKey.Print(0,Game.Instance.ScreenCellsY-2, $"Keys: {_map.UserControlledObject.inventoryKey.Count()}");
            }

            if (_map.UserControlledObject.inventoryBow.Any())
            {
                ((RootScreen)(Game.Instance.Screen)).InventoryBow.Print(0,Game.Instance.ScreenCellsY-1, $"Bow: {_map.UserControlledObject.inventoryBow.Count()}");
            }
        }
        

        return handled;
    }
}