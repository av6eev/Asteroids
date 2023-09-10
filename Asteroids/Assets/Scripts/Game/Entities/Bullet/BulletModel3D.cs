using Game.Entities.Bullet.Base;
using UnityEngine;
using Utilities.Game;

namespace Game.Entities.Bullet
{
    public class BulletModel3D : BaseBulletModel
    {
        public BulletModel3D(Vector3 position, int health, int damage) : base(position, health, damage)
        {
        }

        public override Vector3 GetPosition()
        {
            var position = base.GetPosition();
            return new Vector3(position.x, 0f, position.y);
        }

        public override bool CheckIntersects(GameZoneLimits zoneLimits) => !(Position.x < zoneLimits.LeftSide) && !(Position.x > zoneLimits.RightSide) && !(Position.z >= zoneLimits.TopSide);
    }
}