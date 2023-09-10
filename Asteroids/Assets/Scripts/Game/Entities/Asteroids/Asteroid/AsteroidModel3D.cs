using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using UnityEngine;
using Utilities.Game;

namespace Game.Entities.Asteroids.Asteroid
{
    public class AsteroidModel3D : BaseAsteroidModel
    {
        public AsteroidModel3D(AsteroidSpecification specification, float speedShift) : base(specification, speedShift)
        {
        }

        public AsteroidModel3D(IAsteroidModel asteroidModel) : base(asteroidModel)
        {
        }

        public override Vector3 GetPosition()
        {
            var position = base.GetPosition();
            return new Vector3(position.x, 0, position.y);
        }

        public override void SetPosition(float horizontal, float forward) => Position = new Vector3(horizontal, 0, forward);
        
        public override Tuple<float, float> GetPositionWithOffset(float horizontal, float forward) => new(Position.x + horizontal, Position.z + forward);

        public override bool CheckIntersects(GameZoneLimits limits) => !(Position.x < limits.LeftSide - 3) && !(Position.x > limits.RightSide + 3) && !(Position.z < limits.BottomSide);
    }
}