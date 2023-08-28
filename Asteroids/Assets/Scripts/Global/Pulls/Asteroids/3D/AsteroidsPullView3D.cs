using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid;
using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.Asteroids._3D
{
    public class AsteroidsPullView3D : BasePullView<AsteroidView3D>
    {
        [field: SerializeField] public AsteroidsTypes Type { get; private set; }
    }
}