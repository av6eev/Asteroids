using Game.Entities.Bullet.Base;
using Game.Entities.Ship;
using Game.Entities.Ship.Base;
using Specifications.Base;
using Utilities.Interfaces;

namespace Specifications.Ships.Base
{
    public interface IShipSpecification : ISpecification, IPurchaseable
    {
        int Id { get; }
        ShipsTypes Type { get; }
        string Name { get; }
        int Health { get; }
        IBulletView BulletView3D { get; }
        IBulletView BulletView2D { get; }
        int Count { get; }
        float ReloadTime { get; }
        float ShootRate { get; }
        bool IsAutomatic { get; }
        float Speed { get; }
        IShipView ShipView3D { get; }
        IShipView ShipView2D { get; }
    }
}