using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.Asteroids
{
    public class AsteroidsPullView : BasePullView<AsteroidView>
    {
        [field: SerializeField] public AsteroidsTypes Type { get; private set; }
        [field: SerializeField] public override int Count { get; set; }
    }
}