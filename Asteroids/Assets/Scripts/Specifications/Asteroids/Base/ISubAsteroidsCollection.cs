using System.Collections.Generic;

namespace Specifications.Asteroids.Base
{
    public interface ISubAsteroidsCollection
    {
        List<IAsteroidsSpecificationSo> SubAsteroidsOnDestroy { get; }
    }
}