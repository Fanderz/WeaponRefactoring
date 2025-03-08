using System;

class Weapon
{
    private readonly int _damage;
    private readonly int _bulletsPerShot;

    private int _bullets;

    public Weapon(int damageSize, int gunMagazineSize)
    {
        if (damageSize <= 0 || gunMagazineSize <= 0)
            return new ArgumentOutOfRangeException();

        _damage = damageSize;
        _bullets = gunMagazineSize;

        _bulletsPerShot = 1;
    }

    public void Fire(Player player)
    {
        if (player == null)
            return new ArgumentNullException();

        if (_bullets <= 0)
            return new InvalidOperationException();

        player.TakeDamage(_damage);
        _bullets -= _bulletsPerShot;
    }
}

class Player
{
    private int _health;

    public Player(int healthSize)
    {
        if (healthSize <= 0)
            return new ArgumentOutOfRangeException();

        _health = healthSize;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return new ArgumentOutOfRangeException();

        if (_health >= damage)
            _health -= damage;
    }
}

class Bot
{
    private readonly Weapon _weapon;

    public Bot()
    {
        _weapon = new Weapon();
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            return new ArgumentNullException();

        _weapon.Fire(player);
    }
}