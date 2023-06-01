using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class PlayerMovement
{
    private readonly float _speed;
    private readonly Keyboard.Key _leftButton;
    private readonly Keyboard.Key _rightButton;
    private readonly Keyboard.Key _upButton;
    private readonly Keyboard.Key _downButton;


    public PlayerMovement(PlayerSettings playerSettings)
    {
        _speed = playerSettings.Speed;
        _leftButton = playerSettings.MovingLeftButton;
        _rightButton = playerSettings.MovingRightButton;
        _upButton = playerSettings.MovingUpButton;
        _downButton = playerSettings.MovingDownButton;
    }

    public Vector2f GetNewPosition(Vector2f position)
    {
        var movement = new Vector2f();
        if (Keyboard.IsKeyPressed(_leftButton))
        {
            movement.X -= 1;
        }

        if (Keyboard.IsKeyPressed(_rightButton))
        {
            movement.X += 1;
        }

        if (Keyboard.IsKeyPressed(_upButton))
        {
            movement.Y -= 1;
        }

        if (Keyboard.IsKeyPressed(_downButton))
        {
            movement.Y += 1;
        }

        position += movement.Normalize() * _speed;

        return position;
    }
}