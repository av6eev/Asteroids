using Game.Entities.Bullet.Base;
using UnityEngine;
using Utilities.Game;

namespace Game.Entities.Bullet
{
    public class BulletModel2D : BaseBulletModel
    {
        public BulletModel2D(Vector3 position, int health, int damage) : base(position, health, damage)
        {
        }

        public override Vector3 GetPosition()
        {
            var position = base.GetPosition();
            return new Vector3(position.x, position.z, 0f);
        }

        public override bool CheckIntersects(GameZoneLimits zoneLimits) => !(Position.x <= zoneLimits.LeftSide) && !(Position.x >= zoneLimits.RightSide) && !(Position.y >= zoneLimits.TopSide);
    }
}