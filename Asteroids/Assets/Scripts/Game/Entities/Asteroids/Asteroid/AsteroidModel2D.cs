using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using Specifications.Asteroids.Base;
using UnityEngine;
using Utilities.Game;

namespace Game.Entities.Asteroids.Asteroid
{
    public class AsteroidModel2D : BaseAsteroidModel
    {
        public AsteroidModel2D(IAsteroidSpecification specification, float speedShift) : base(specification, speedShift)
        {
        }

        public AsteroidModel2D(IAsteroidModel asteroidModel) : base(asteroidModel)
        {
        }
        
        public override Vector3 GetPosition()
        {
            var position = base.GetPosition();
            return new Vector3(position.x, position.z, 0);
        }

        public override void SetPosition(float horizontal, float forward) => Position = new Vector3(horizontal, forward, 0);
        
        public override Tuple<float, float> GetPositionWithOffset(float horizontal, float forward) => new(Position.x + horizontal, Position.y + forward);

        public override bool CheckIntersects(GameZoneLimits limits) => !(Position.x < limits.LeftSide - 3) && !(Position.x > limits.RightSide + 3) && !(Position.y < limits.BottomSide);
    }
}