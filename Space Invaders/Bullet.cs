using SFML.Graphics;
using SFML.System;

namespace Space_Invaders;

public class Bullet
{
    private readonly float _bulletSpeed;
    private readonly CircleShape _bulletshape;
    private readonly float _bulletRadius;
    public Vector2f Position => _bulletshape.Position;

    public Bullet(Vector2f position, float bulletSpeed, float bulletRadius)
    {
        _bulletSpeed = bulletSpeed;
        _bulletshape = new CircleShape(bulletRadius);
        _bulletshape.FillColor = Color.Red;
        _bulletshape.Position = position;
    }

    public void Update()
    {
        var currentPosition = _bulletshape.Position;
        var newPosition = new Vector2f(currentPosition.X, currentPosition.Y - _bulletSpeed);
        _bulletshape.Position = newPosition;
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(_bulletshape);
    }

    public CircleShape GetBulletShape()
    {
        return _bulletshape;
    }

    public FloatRect GetGlobalBounds()
    {
        return _bulletshape.GetGlobalBounds();
    }
}