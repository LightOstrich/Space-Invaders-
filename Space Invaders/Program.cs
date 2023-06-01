using SFML.Graphics;
using SFML.Window;

namespace Space_Invaders;

public class Program
{
    private const string GAME_CONFIGURATION_JSON_PATH = "GameConfiguration.json";

    static void Main(string[] args)
    {
        var gameconfiguration = new GameConfiguration(GAME_CONFIGURATION_JSON_PATH);
        Game game = new Game(gameconfiguration);
        game.Run();
        game.ShowGameOverScreen();
    }
}