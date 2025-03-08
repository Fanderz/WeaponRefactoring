using System;

class Weapon
{
    private readonly int _damage;
    private readonly int _bulletsPerShot;

    private int _bullets;

    public Weapon(int damageSize, int gunMagazineSize)
    {
        if (damageSize <= 0)
            throw new ArgumentOutOfRangeException();

        if (gunMagazineSize <= 0)
            throw new ArgumentOutOfRangeException();

        _damage = damageSize;
        _bullets = gunMagazineSize;

        _bulletsPerShot = 1;
    }

    public void Fire(Player player)
    {
        if (player == null)
            throw new ArgumentNullException();

        if (_bullets <= 0)
            throw new InvalidOperationException();

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
            throw new ArgumentOutOfRangeException();

        _health = healthSize;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException();

        if (_health >= damage)
            _health -= damage;
        else
            Die();
    }

    private void Die()
    {
        _health = 0;
    }
}

class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException();

        _weapon.Fire(player);
    }
}