using System;
using System.Collections.Generic;
using Specifications.Base;

namespace Specifications.GameDifficulties.Collection
{
    [Serializable]
    public class GameDifficultiesCollectionSpecification : ISpecification
    {
        public List<GameDifficultySpecificationSo> Difficulties;
    }
}