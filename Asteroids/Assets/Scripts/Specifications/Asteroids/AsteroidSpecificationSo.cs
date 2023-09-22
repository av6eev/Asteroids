using Specifications.Asteroids.Base;
using Specifications.Base;
using UnityEngine;

namespace Specifications.Asteroids
{
    [CreateAssetMenu(menuName = "Create Specification/New Asteroid", fileName = "AsteroidSpecification", order = 51)]
    public class AsteroidSpecificationSo : SpecificationSo<AsteroidSpecification>, IAsteroidsSpecificationSo
    {
        public IAsteroidSpecification Get() => Specification;
    }

    public interface IAsteroidsSpecificationSo
    {
        IAsteroidSpecification Get();
    }
}