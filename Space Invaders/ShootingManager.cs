using SFML.Graphics;
using SFML.System;

namespace Space_Invaders;

public class ShootingManager
{
    public List<Bullet> Bullets { get; } = new();
    private readonly float _bulletSpeed;
    private readonly float _bulletRadius;

    private readonly float _shootingCooldown;
    private readonly Clock _clock = new();

    public ShootingManager(float bulletSpeed, float bulletRadius, float shootingCooldowm)
    {
        _bulletRadius = bulletRadius;
        _bulletSpeed = bulletSpeed;
        _shootingCooldown = shootingCooldowm;
    }

    public void TryShoot(Vector2f bulletSpawnPosition)
    {
        var lastShotTime = _clock.ElapsedTime.AsSeconds();
        if (lastShotTime >= _shootingCooldown)
        {
            var bullet = new Bullet(bulletSpawnPosition, _bulletSpeed, _bulletRadius);
            Bullets.Add(bullet);
            _clock.Restart();
        }
    }

    private bool IsBulletOutOfScreen(Bullet bullet)
    {
        return bullet.Position.Y < 0;
    }

    public void Update()
    {
        for (var i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].Update();
            if (IsBulletOutOfScreen(Bullets[i]))
            {
                Bullets.RemoveAt(i);
            }
        }
    }

    public void Draw(RenderWindow window)
    {
        for (var i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].Draw(window);
        }
    }
}