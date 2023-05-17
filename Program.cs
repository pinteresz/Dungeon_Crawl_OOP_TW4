using DungeonCrawl.Tiles;
using DungeonCrawl.Ui;
using SadConsole;

namespace DungeonCrawl;

/// <summary>
/// Class <c>Program</c> provides an entry point for the game.
/// </summary>
public static class Program
{
    private const int ViewPortWidth = 80;
    private const int ViewPortHeight = 25;

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    public static void Main()
    {
        // Setup the engine and create the main window.
        Game.Create(ViewPortWidth, ViewPortHeight);

        // Hook the start event so we can add consoles to the system.
        Game.Instance.OnStart = Init;

        // Start the game.
        Game.Instance.Run();
        Game.Instance.Dispose();
    }

    /// <summary>
    /// Initializes the game.
    /// </summary>
    private static void Init()
    {
        Game.Instance.Screen = new RootScreen();
        Game.Instance.Screen.IsFocused = true;
        
        var console = new Console(ViewPortWidth, ViewPortHeight);
        console.IsFocused = false;
        console.Cursor.IsVisible = false;
        
        var console1 = new Console(ViewPortWidth, ViewPortHeight);
        console1.IsFocused = false;
        console1.Cursor.IsVisible = false;
        
        var console2 = new Console(ViewPortWidth, ViewPortHeight);
        console1.IsFocused = false;
        console1.Cursor.IsVisible = false;
        
        ((RootScreen)(Game.Instance.Screen)).Console = console;
        Game.Instance.Screen.Children.Add(((RootScreen)(Game.Instance.Screen)).Console);
        
        // var console = new Console(ViewPortWidth, ViewPortHeight);
        // console.IsFocused = false;
        // console.Cursor.IsVisible = false;
        
        ((RootScreen)(Game.Instance.Screen)).InventoryTreasure = console1;
        Game.Instance.Screen.Children.Add(((RootScreen)(Game.Instance.Screen)).InventoryTreasure);
        
        ((RootScreen)(Game.Instance.Screen)).InventoryKey = console1;
        Game.Instance.Screen.Children.Add(((RootScreen)(Game.Instance.Screen)).InventoryTreasure);
        
        ((RootScreen)(Game.Instance.Screen)).InventoryBow = console1;
        Game.Instance.Screen.Children.Add(((RootScreen)(Game.Instance.Screen)).InventoryTreasure);
        
        ((RootScreen)(Game.Instance.Screen)).HealthBar = console1;
        Game.Instance.Screen.Children.Add(((RootScreen)(Game.Instance.Screen)).HealthBar);

        ((RootScreen)(Game.Instance.Screen)).GameOver = console2;
        Game.Instance.Screen.Children.Add(((RootScreen)(Game.Instance.Screen)).GameOver);
        
        // This is needed because we replaced the initial screen object with our own.
        Game.Instance.DestroyDefaultStartingConsole();
    }
}